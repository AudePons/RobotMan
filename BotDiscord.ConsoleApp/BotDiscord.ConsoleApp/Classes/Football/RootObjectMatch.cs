using BotDiscord.ConsoleApp.Data.Football;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data
{
    public class RootObjectMatch
    {
        public int count { get; set; }
        public FiltersMatch filters { get; set; }
        public Competition competition { get; set; }
        public List<Match> matches { get; set; }
    }
}
