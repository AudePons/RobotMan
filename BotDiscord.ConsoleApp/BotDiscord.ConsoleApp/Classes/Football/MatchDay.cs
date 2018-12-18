using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data.Football
{
    public class MatchDay
    {
        public int id { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public DateTime utcDate { get; set; }
        public string status { get; set; }
        public int matchday { get; set; }
        public string stage { get; set; }
        public string group { get; set; }
        public DateTime lastUpdated { get; set; }
        public Score score { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public List<object> referees { get; set; }
    }
}
