using Discord.Commands;
using System.Threading.Tasks;
using System;

namespace BotDiscord.ConsoleApp.Modules
{
    [Name("PSR")]
    [Summary("Paper, Scissord, rock")]
    public class GamePSRModule : ModuleBase<SocketCommandContext>
    {
        public string[] psr = { "pierre", "feuille", "ciseaux" };
        public Random randGen = new Random();

        [Command("start-psr")]
        [Summary("Start game")]
        public Task startPSR(string word)
        {
            word = word.ToLower();

            var randIndex = randGen.Next(0, 2);
            string botValue = psr[randIndex];
            string messageNull = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est un match nul, aucun gagnant. :| ";
            string messageBotWin = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est moi qui gagne !!! :D ";
            string messageUserWin = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est toi qui gagne ... :(";
            string message = "";

            if (word == "ciseaux" || word == "pierre" || word == "feuille")
            {
                if (word == botValue)
                {
                    message = messageNull;
                }
                else if (word == "pierre" && botValue == "feuille")
                {
                    message += messageBotWin;
                }
                else if (word == "feuille" && botValue == "pierre")
                {
                    message += messageUserWin;
                }
                else if (word == "pierre" && botValue == "ciseaux")
                {
                    message += messageUserWin;
                }
                else if (word == "ciseaux" && botValue == "pierre")
                {
                    message += messageBotWin;
                }
                else if (word == "ciseaux" && botValue == "feuille")
                {
                    message += messageUserWin;
                }
                else if (word == "feuille" && botValue == "ciseaux")
                {
                    message += messageBotWin;
                }
            }
            else
            {
                message = "Veuillez choisir entre pierre, feuille ou ciseaux";
            }
            return ReplyAsync(message);
        }
    }
}
