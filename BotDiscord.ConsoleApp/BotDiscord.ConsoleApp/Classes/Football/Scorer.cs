using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Data.Football
{
    public class Scorer
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public int numberOfGoals { get; set; }
    }
}
