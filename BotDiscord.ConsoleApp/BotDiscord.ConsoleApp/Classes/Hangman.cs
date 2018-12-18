using System;
using System.Collections.Generic;
using System.Text;

namespace BotDiscord.ConsoleApp.Classes
{
    public sealed class Hangman
    {
        public string[] words = { "papillon", "ours", "mouton", "tigre", "lion", "chien", "chat" };
        public string mysteryWord;
        public int lengthMysteryWord;
        public int chance;
        public string[] hidenWord = new string[90];

        public Random randGen = new Random();

        private static Hangman instance = null;

        private Hangman()
        {
            var randIndex = randGen.Next(0, 6);
            mysteryWord = words[randIndex];
            lengthMysteryWord = mysteryWord.Length;
            for (int i = 0; i < mysteryWord.Length; i++)
            {
                hidenWord[i] = "X";
            }
            chance = 9;
        }

        public static Hangman Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Hangman();
                }
                return instance;
            }
        }
        
        public string TheMysteryWord
        {
            get { return mysteryWord; }
        }

        public int LengthMysteryWord
        {
            get {  return lengthMysteryWord; }
        }

        public int NbChance
        {
            get { return chance; }
            set { chance = value; }
        }

        public string[] FindLetter
        {
            get { return hidenWord; }
            set { hidenWord = value; }
        }
    }
}
