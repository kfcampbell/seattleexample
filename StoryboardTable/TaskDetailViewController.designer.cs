// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace StoryboardTable
{
	[Register ("TaskDetailViewController")]
	partial class TaskDetailViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView detail { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel homeLabel0 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel homeLabel1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel homeLabel2 { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (detail != null) {
				detail.Dispose ();
				detail = null;
			}
			if (homeLabel0 != null) {
				homeLabel0.Dispose ();
				homeLabel0 = null;
			}
			if (homeLabel1 != null) {
				homeLabel1.Dispose ();
				homeLabel1 = null;
			}
			if (homeLabel2 != null) {
				homeLabel2.Dispose ();
				homeLabel2 = null;
			}
		}
	}
}