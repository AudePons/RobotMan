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
            var randIndex = randGen.Next(0, 2);
            string botValue = psr[randIndex];
            string messageNull = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est un match NULL, aucun gagnant.";
            string messageBotWin = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est moi qui gagne !!!";
            string messageUserWin = "Tu me dis " + word + ", et je te dis " + botValue + ". C'est toi qui gagne ...";
            string message = "";

            if(word == botValue)
            {
                message = messageNull;
            }
            if(word == "pierre" && botValue == "feuille")
            {
                message += messageBotWin;
            }
            if(word == "feuille" && botValue == "pierre")
            {
                message += messageUserWin;
            }
            if(word == "pierre" && botValue == "ciseaux")
            {
                message += messageUserWin;
            }
            if(word == "ciseaux" && botValue == "pierre")
            {
                message += messageBotWin;
            }
            if(word == "ciseaux" && botValue == "feuille")
            {
                message += messageUserWin;
            }
            if(word == "feuille" && botValue == "ciseaux")
            {
                message += messageBotWin;
            }
            return ReplyAsync(message);
        }
    }
}
