using System;
using CoreGraphics;
using System.Collections.Generic;
using Foundation;
using UIKit;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using Mono;
using Newtonsoft.Json.Linq;

namespace StoryboardTable
{
	public partial class MasterViewController : UITableViewController
	{
		List<Game> allGames = new List<Game>();
		JToken pitch;
		JToken bat;
		string homeTeam;
		string awayTeam;

		public MasterViewController (IntPtr handle) : base (handle)
		{
			Title = "Games Today";

			#region JSON Stuff
			// get the current date for api querying
			var startDate = new DateTime ();
			startDate = DateTime.Now.ToLocalTime ();
			Console.Out.WriteLine ("datetime: " + startDate.ToString());

			// need special handling for single digits months and years
			int day = startDate.Day;
			int year = startDate.Year;
			int month = startDate.Month;

			string daystring;
			string monthstring;
			if(day < 10)
			{
				daystring = "0" + day;
			}
			else
			{
				daystring = day.ToString ();
			}

			if(month < 10)
			{
				monthstring = "0" + month;
			}
			else
			{
				monthstring = month.ToString ();
			}

			string apiurl = "http://gd2.mlb.com/components/game/mlb/year_"
				+ year + "/month_" + monthstring + "/day_" + daystring + "/master_scoreboard.json";
			Console.Out.WriteLine("url: " + apiurl);

			// make the actual request for the data
			var request = HttpWebRequest.Create(string.Format(@apiurl));
			request.ContentType = "application/json";
			request.Method = "GET";

			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				if (response.StatusCode != HttpStatusCode.OK)
					Console.Out.WriteLine("Error fetching data. Server returned status code: {0}", response.StatusCode);
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					var content = reader.ReadToEnd();
					if(string.IsNullOrWhiteSpace(content)) 
					{
						Console.Out.WriteLine("Response contained empty body...");
					}
					else 
					{
						// call function to parse data using json.
						// get the whole thing
						JObject information = JObject.Parse (content);

						// get the games list
						JToken data = information ["data"];
						Console.Out.WriteLine ("data: " + data.ToString());

						// grab the "games" item
						JToken games = data ["games"];
						Console.Out.WriteLine ("gameZ: " + games.ToString ());

						// grab the "game" item with all the day's games
						JToken game = games["game"];
						Console.Out.WriteLine ("game: " + game.ToString ());

						// get the array of all games
						JEnumerable<JToken> children = game.Children ();

						// iterate through to check for a mariners game
						using (var seqEnum = children.GetEnumerator())
						{
							while(seqEnum.MoveNext())
							{
								JToken curr = seqEnum.Current;

								// if there's a game today and it hasn't started yet
								if(curr["home_probable_pitcher"] != null)
								{
									Console.Out.WriteLine ("Mariners game found: " + curr ["away_team_name"].ToString ());

									pitch = curr["away_probable_pitcher"];
									bat = curr["home_probable_pitcher"];

									homeTeam = curr ["home_team_name"].ToString ();
									awayTeam = curr ["away_team_name"].ToString ();

									Game newGame = new Game () 
									{ 
										pitcher = pitch, batter = bat,
										hometeam = homeTeam, awayteam = awayTeam, 
										homelosses = curr["home_loss"].ToString(), homewins = curr["home_win"].ToString(),
										awaylosses = curr["away_loss"].ToString(), awaywins = curr["away_win"].ToString(),
										starttime = curr["home_time"].ToString(), timezone = curr["home_time_zone"].ToString(),
										status = "before",};
									allGames.Add(newGame);
								}

								// found a current game
								else if(curr["due_up_batter"] != null)
								{
									JToken linescore = curr["linescore"];
									Game newGame = new Game ()
									{ 
										pitcher = curr["pitcher"], batter = curr["due_up_batter"], 
										hometeam = curr["home_team_name"].ToString(), awayteam = curr["away_team_name"].ToString(),
										homelosses = curr["home_loss"].ToString(), homewins = curr["home_win"].ToString(),
										awaylosses = curr["away_loss"].ToString(), awaywins = curr["away_win"].ToString(),
										starttime = curr["home_time"].ToString(), timezone = curr["home_time_zone"].ToString(),
										status = "during", score = linescore["r"],};
									allGames.Add(newGame);
								}
								// found a game that's over
								else if(curr["winning_pitcher"] != null)
								{
									JToken linescore = curr["linescore"];
									Game newGame = new Game () 
									{ 
										pitcher = curr["winning_pitcher"], batter = curr["losing_pitcher"], 
										hometeam = curr["home_team_name"].ToString(), awayteam = curr["away_team_name"].ToString(),
										homelosses = curr["home_loss"].ToString(), homewins = curr["home_win"].ToString(),
										awaylosses = curr["away_loss"].ToString(), awaywins = curr["away_win"].ToString(),
										starttime = curr["home_time"].ToString(), timezone = curr["home_time_zone"].ToString(),
										status = "after", score = linescore["r"],};
									allGames.Add(newGame);
								}
								else // should never happen, but just in case
								{
									Game newGame = new Game () 
									{	
										hometeam = curr["home_team_name"].ToString(), awayteam = curr["away_team_name"].ToString(),
										homelosses = curr["home_loss"].ToString(), homewins = curr["home_win"].ToString(),
										awaylosses = curr["away_loss"].ToString(), awaywins = curr["away_win"].ToString(),
										starttime = curr["home_time"].ToString(), timezone = curr["home_time_zone"].ToString(),
										status = "who the fuck knows",};
									allGames.Add(newGame);
								}
							}
						}
					}
				}
			}
			#endregion
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "TaskSegue") { // set in Storyboard
				var navctlr = segue.DestinationViewController as TaskDetailViewController;
				if (navctlr != null) {
					var source = TableView.Source as RootTableSource;
					var rowPath = TableView.IndexPathForSelectedRow;
					var item = source.GetItem(rowPath.Row);
					navctlr.SetTask (this, item); // to be defined on the TaskDetailViewController
				}
			}
		}

		public void CreateTask ()
		{
			// first, add the task to the underlying data
			var newId = allGames[allGames.Count - 1].Id + 1;
			var newGame = new Game(){Id=newId};
			allGames.Add (newGame);

			// then open the detail view to edit it
			var detail = Storyboard.InstantiateViewController("detail") as TaskDetailViewController;
			detail.SetTask (this, newGame);
			NavigationController.PushViewController (detail, true);
		}

		public void SaveTask (Game chore)
		{
			//var oldTask = chores.Find(t => t.Id == chore.Id);
			NavigationController.PopViewController(true);
		}

		public void DeleteTask (Game chore)
		{
			var oldTask = allGames.Find(t => t.Id == chore.Id);
			allGames.Remove (oldTask);
			NavigationController.PopViewController(true);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			// bind every time, to reflect deletion in the Detail view
			TableView.Source = new RootTableSource(allGames.ToArray ());
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

	}
}

