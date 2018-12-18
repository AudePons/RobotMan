using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data
{
    public class Competition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string plan { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
