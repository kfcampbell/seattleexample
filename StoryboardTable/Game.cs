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
	}
}

