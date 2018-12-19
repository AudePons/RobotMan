using System;

namespace BotDiscord.ConsoleApp.Classes
{
    public sealed class Trueprice
    {
        public int price = 0;
        public int chance;
        public Random randGen = new Random();

        private static Trueprice instance = null;

        private Trueprice()
        {
            price = randGen.Next(0, 1000);
            chance = 10;
        }
        
        public static Trueprice Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Trueprice();
                }
                return instance;
            }
        }
        
        public int TheTruePriceValue
        {
            get { return price;  }
        }

        public int NbChance
        {
            get { return chance; }
            set { chance = value; }
        }
    }
}
