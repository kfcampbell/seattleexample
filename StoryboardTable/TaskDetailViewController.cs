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
			homeLabel2.Text = currentGame.batter ["first"] + ", " + currentGame.pitcher ["first"];
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		// this will be called before the view is displayed
		public void SetTask (MasterViewController d, Game game) 
		{
			Delegate = d;
			currentGame = game;
		}
	}
}
