using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace StoryboardTable
{
	partial class TaskDetailViewController : UITableViewController
	{
		Game currentGame {get;set;}
		public MasterViewController Delegate {get;set;} // will be used to Save, Delete later

		public TaskDetailViewController (IntPtr handle) : base (handle)
		{
			
		}

		// when displaying, set-up the properties
		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();
			homeLabel0.Text = "Away Team: " + currentGame.awayteam;
			homeLabel1.Text = "Home Team: " + currentGame.hometeam;
			try
			{
				homeLabel2.Text = 
					currentGame.pitcher ["first"] + " " + currentGame.pitcher ["last"]
					+ " vs. " + currentGame.batter ["first"] + " " + currentGame.batter["last"];
				
			}
			catch(Exception ex)
			{
				awayLabel2.Text = "Game not in progress";
				Console.Out.WriteLine (ex.ToString ());
			}
			awayLabel0.Text = currentGame.hometeam + " record: " + currentGame.homewins + "-" + currentGame.homelosses;
			awayLabel1.Text = currentGame.awayteam + " record: " + currentGame.awaywins + "-" + currentGame.awaylosses;
			awayLabel2.Text = "Start Time: " + currentGame.starttime + " " + currentGame.timezone;

			try
			{
				awayLabel3.Text = currentGame.awayteam + "  " + currentGame.score ["away"] + "    --    "
					+ currentGame.score ["home"] + "  " + currentGame.hometeam;
			}
			catch(Exception ex)
			{
				awayLabel3.Text = "Game not in progress";
				Console.Out.WriteLine (ex.ToString ());
			}
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			if(currentGame.status == "before")
			{
				Title = "Game start: " + currentGame.starttime + " " + currentGame.timezone;
			}
			else if(currentGame.status == "during")
			{
				Title = "Game in Progress";
			}
			else if(currentGame.status == "after")
			{
				Title = "Final";
			}
			else
			{
				Title = "who the fuck knows";
			}
		}

		// this will be called before the view is displayed
		public void SetTask (MasterViewController d, Game game) 
		{
			Delegate = d;
			currentGame = game;
		}
	}
}
