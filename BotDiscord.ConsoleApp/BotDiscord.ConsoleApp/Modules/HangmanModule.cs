using Discord.Commands;
using System.Linq;
using System.Threading.Tasks;
using System;
using BotDiscord.ConsoleApp.Classes;

namespace BotDiscord.ConsoleApp.Modules
{
    [Name("Hangman")]
    [Summary("Find the mystery word")]
    public class HangmanModule : ModuleBase<SocketCommandContext>
    {
        [Command("info-hangman")]
        [Summary("Give all commands to play hangman game")]
        public Task InfoHangman()
        {
            return ReplyAsync("Pour jouer avec moi du pendu, tu disposes des commandes suivantes : \n" +
                "   • !start : Initialise le jeu. \n" +
                "   • !indice : Donne un indice. \n" +
                "   • !chance : Donne le nombre d'essai restant. \n" +
                "   • !find : Donne les lettres déjà trouvée. \n" +
                "   • !letter : Réalise une proposition de lettre. \n" +
                "   • !forfeit : Donne le résultat. ");
        }
        
        [Command("start")]
        [Summary("Initialize the game")]
        public Task StartHangman()
        {
            string mot = Hangman.Instance.TheMysteryWord;
            int taille = Hangman.Instance.LengthMysteryWord;
            return ReplyAsync("Oh c'est super, enfin des gens pour jouer avec moi ! Le but du jeu est simple, tu dois deviner le mot que je viens de choisir, mais attention tu as seulement 9 essais ! C'est parti !");
        }

        [Command("indice")]
        [Summary("Give help to find the mystery word")]
        public Task GiveIndice()
        {
            return ReplyAsync("Ah, tu sèches, tu veux un indice ? Comme je suis un robot super gentil je t'en donne un. Le mot est composé de : " + Hangman.Instance.LengthMysteryWord + " lettres.");
        }

        [Command("chance")]
        [Summary("Give the number of test remaining")]
        public Task NbChance()
        {
            return ReplyAsync("Il te reste encore " + Hangman.Instance.NbChance + " chances pour trouver le mot mystère.");
        }

        [Command("find")]
        [Summary("Give the letter find")]
        public Task FindLetter()
        {
            string findLetter = "";
            for (int i = 0; i<Hangman.Instance.LengthMysteryWord; i++)
            {
                findLetter += Hangman.Instance.FindLetter[i] + " ";
            }
            return ReplyAsync(" Voici les lettres que tu as déjà trouvé : " + findLetter + ".");
        }

        [Command("letter")]
        [Summary("Compare letter with mystery word")]
        public Task CompareLetter(string letter = null)
        {
            int nbLetterFind = 0;
            string message = "";
            int find = 0;

            if (letter == null)
            {
                if (Hangman.Instance.NbChance == 0)
                {
                    message += "Désolé, tu as perdu. Le mot mystère était " + Hangman.Instance.TheMysteryWord;
                }
                else if (Hangman.Instance.FindLetter.Contains("X") && Hangman.Instance.NbChance != 0)
                {
                    message += "Il te reste encore des essais. A toi de jouer !";
                }
                else if (Hangman.Instance.FindLetter.Contains("X") == false && Hangman.Instance.NbChance != 0)
                {
                    message += "Félicitation tu as gagné ! Le mot mystère était " + Hangman.Instance.TheMysteryWord + ".";
                }
            }
            else
            {
                if (Hangman.Instance.NbChance == 0)
                {
                    message += "Désolé, tu as perdu. Le mot mystère était " + Hangman.Instance.TheMysteryWord;
                }
                else if (Hangman.Instance.FindLetter.Contains("X") && Hangman.Instance.NbChance != 0)
                {
                    for (int i = 0; i < Hangman.Instance.LengthMysteryWord; i++)
                    {
                        if (Hangman.Instance.FindLetter[i] == letter)
                        {
                            find += 1;
                            nbLetterFind += 1;
                        }
                        else if (letter == Hangman.Instance.TheMysteryWord[i].ToString())
                        {
                            Hangman.Instance.FindLetter[i] = letter;
                            nbLetterFind += 1;
                        }
                    }
                    if (nbLetterFind != 0 || find > 0)
                    {
                        if (find > 0)
                        {
                            message += "La lettre -( " + letter + " )- que tu proposes a déjà été trouvée.";
                        }
                        else
                        {
                            message += "Félicitation, la lettre -( " + letter + " )- est présente " + nbLetterFind + " fois dans le mot mystère.";
                        }
                    }
                    if (nbLetterFind == 0)
                    {
                        if (Hangman.Instance.NbChance != 0)
                        {
                            Hangman.Instance.NbChance = Hangman.Instance.NbChance - 1;
                        }
                        else
                        {
                            Hangman.Instance.NbChance = 0;
                        }
                        message += "Désolé, la lettre -( " + letter + " )- que tu proposes ne se trouve pas dans le mot mystère.";
                    }
                }
                else if (Hangman.Instance.FindLetter.Contains("X") == false && Hangman.Instance.NbChance != 0)
                {
                    message += "Félicitation tu as gagné ! Le mot mystère était " + Hangman.Instance.TheMysteryWord + ".";
                }
            }
            return ReplyAsync(message);
        }

        [Command("forfeit")]
        [Summary("Forfeit")]
        public Task AcceptForfeit()
        {
            Hangman.Instance.NbChance = 0;
            return ReplyAsync("Oh tu donnes ta langue au chat ? Bon, tammpis. Du coup le mot mystère était : " + Hangman.Instance.TheMysteryWord + ".");
        }
    }
}
