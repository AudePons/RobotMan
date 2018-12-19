using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using System;
using BotDiscord.ConsoleApp.Classes;

namespace BotDiscord.ConsoleApp.Modules
{
    [Name("Trueprice")]
    [Summary("Find the true price")]
    public class TruepriceModule : ModuleBase<SocketCommandContext>
    {
        [Command("info-tp")]
        [Summary("Give all commands to play true price game")]
        public Task InfoTruePrice()
        {
            return ReplyAsync("Pour jouer avec moi au juste prix, tu disposes des commandes suivantes : \n" +
                "   • !start-tp : Initialise le jeu. \n" +
                "   • !chance-tp : Donne le nombre d'essai restant. \n" +
                "   • !price : Réalise une proposition de prix. \n" +
                "   • !forfeit-tp : Donne le résultat. ");
        }

        [Command("start-tp")]
        [Summary("Initialize the game")]
        public Task StartTrueprice()
        {
            int priceValue = Trueprice.Instance.TheTruePriceValue;
            return ReplyAsync("Oh, mais c'est génial ! Le but du jeu est simple. Je vais choisir une valeur entre 0 et 1000, et tu dois la deviner. Mais attention tu as seulement 10 chances ! C'est parti !");
        }

        [Command("price")]
        [Summary("Compare user value with bot value")]
        public Task ComparePrice(int price)
        {
            string message = "";

            if(Trueprice.Instance.NbChance == 0)
            {
                message += "Désolé tu as perdu. Le prix mystère était " + Trueprice.Instance.TheTruePriceValue + ".";
            }
            else
            {
                if(price == Trueprice.Instance.TheTruePriceValue)
                {
                    message += "Bravo tu as gagné ! En effet, le prix mystère était : " + Trueprice.Instance.TheTruePriceValue + ".";
                }
                else if(price > Trueprice.Instance.TheTruePriceValue)
                {
                    Trueprice.Instance.NbChance = Trueprice.Instance.NbChance - 1;
                    message += "Le prix que tu proposes est plus élévé que le prix mystère.";
                }
                else if(price < Trueprice.Instance.TheTruePriceValue)
                {
                    Trueprice.Instance.NbChance = Trueprice.Instance.NbChance - 1;
                    message += "Le prix que tu proposes est trop bas par rapport au prix mystère.";
                }
            }
            return ReplyAsync(message);
        }

        [Command("chance-tp")]
        [Summary("Give the number of test remaining")]
        public Task NbChancePrice()
        {
            return ReplyAsync("Il te reste actuellement " + Trueprice.Instance.NbChance + ".");
        }

        [Command("forfeit-tp")]
        [Summary("forfeit")]
        public Task AcceptForfeitPrice()
        {
            Trueprice.Instance.NbChance = 0;
            return ReplyAsync("Oh tu donnes ta langue au chat ? Bon, tammpis. Du coup le prix mystère était : " + Trueprice.Instance.TheTruePriceValue + ".");
        }
    }
}
