using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data.Football
{
    public class RootObjectScorers
    {
        public int count { get; set; }
        public FiltersMatch filters { get; set; }
        public Competition competition { get; set; }
        public Season season { get; set; }
        public List<Scorer> scorers { get; set; }
    }
}
