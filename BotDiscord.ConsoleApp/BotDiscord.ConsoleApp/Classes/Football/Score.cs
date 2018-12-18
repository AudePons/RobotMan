using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data
{
    public class Score
    {
        public string winner { get; set; }
        public string duration { get; set; }
        public FullTime fullTime { get; set; }
        public HalfTime halfTime { get; set; }
        public ExtraTime extraTime { get; set; }
        public Penalties penalties { get; set; }
    }
}
