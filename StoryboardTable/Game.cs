using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StoryboardTable {

	/// <summary>
	/// Represents a Chore.
	/// </summary>
	///
	public class Game {

		public Game ()
		{
		}
		public int Id { get; set; }
		public JToken pitcher { get; set; }
		public JToken batter { get; set; }
		public string hometeam { get; set; }
		public string awayteam { get; set; }
		public string homewins { get; set; }
		public string homelosses { get; set; }
		public string awaywins { get; set; }
		public string awaylosses { get; set; }
		public string starttime { get; set; }
		public string timezone { get; set; }
		public string status { get; set; }
		public JToken score { get; set; }
	}
}

