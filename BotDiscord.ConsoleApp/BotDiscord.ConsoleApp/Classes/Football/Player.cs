using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data.Football
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public object lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string countryOfBirth { get; set; }
        public string nationality { get; set; }
        public string position { get; set; }
        public int shirtNumber { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
