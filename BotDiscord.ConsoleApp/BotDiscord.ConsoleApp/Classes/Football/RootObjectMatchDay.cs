using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data.Football
{
    public class RootObjectMatchDay
    {
        public int count { get; set; }
        public FiltersMatchDay filters { get; set; }
        public List<MatchDay> matches { get; set; }
    }
}
