using System;
using UIKit;

namespace StoryboardTable
{
	public class RootTableSource : UITableViewSource {

		// there is NO database or storage of Tasks in this example, just an in-memory List<>
		Game[] tableItems;
		string cellIdentifier = "taskcell"; // set in the Storyboard

		public RootTableSource (Game[] items)
		{
			tableItems = items;
		}
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return tableItems.Length;
		}
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			// in a Storyboard, Dequeue will ALWAYS return a cell,
			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
			// now set the properties as normal
			cell.TextLabel.Text = tableItems[indexPath.Row].awayteam + " at " + tableItems[indexPath.Row].hometeam;
			cell.Accessory = UITableViewCellAccessory.None; // this is where you'd set logos if that became a thing
			return cell;
		}
		public Game GetItem(int id) {
			return tableItems[id];
		}
	}
}

