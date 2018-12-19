using Discord.Commands;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using BotDiscord.ConsoleApp.Classes;
using BotDiscord.ConsoleApp.Data;
using BotDiscord.ConsoleApp.Data.Football;

namespace BotDiscord.ConsoleApp.Modules
{
    [Name("Football")]
    [Summary("Ok, football fan, what do you want to know about this season")]
    public class FootballModule : ModuleBase<SocketCommandContext>
    {
        [Command("infofoot")]
        [Summary("Get the list of games already played")]
        public async Task infoCommandFootball()
        {
            string rendu = "" +
                "Les championnats possibles sont : \n" +
                "- BL1 (Bundesliga) \n" +
                "- PL (Premier League) \n" +
                "- SA (Série A) \n" +
                "- PD (Primera Division Esp) \n" +
                "- FL1 (Ligue 1) \n";
            await ReplyAsync(rendu);
        }

        [Command("matchplayed")]
        [Summary("Get the list of games already played")]
        public async Task matchplayed(string competition, int day)
        {
            try
            {
                String result;
                WebClient client = new WebClient();
                String address = @"https://api.football-data.org/v2/competitions/" + competition + "/matches?matchday=" + day;
                client.Headers.Add("X-Auth-Token", "your token");

                result = client.DownloadString(address);
                var data = JsonConvert.DeserializeObject<RootObjectMatch>(result);
                string rendu = "";
                foreach (Match match in data.matches)
                {
                    var score = match.score.fullTime;
                    rendu += match.homeTeam.name + "  " + score.homeTeam + " - " + score.awayTeam + "  " + match.awayTeam.name + "\n";
                }
                await ReplyAsync(rendu);
            }
            catch (Exception e)
            {
                await ReplyAsync("Veuillez entrer un championnat existant et une journée ayant déjà été jouée");
            }
            
        }

        [Command("scorers")]
        [Summary("Get the top 10 scorers of each championship")]
        public async Task scorers(string competition)
        {
            try
            { 
                String result;
                WebClient client = new WebClient();
                String address = @"https://api.football-data.org/v2/competitions/"+competition+"/scorers";
                client.Headers.Add("X-Auth-Token", "your token");
                result = client.DownloadString(address);
                var data = JsonConvert.DeserializeObject<RootObjectScorers>(result);
                string rendu = "Voici le top 10 des buteurs de votre championnat : \n \n ";
                foreach (Scorer scorer in data.scorers)
                {
                    rendu += scorer.player.name + " : " + scorer.numberOfGoals + " \n";
                }
                await ReplyAsync(rendu);
            }
            catch (Exception e)
            {
                await ReplyAsync("Veuillez entrer un championnat existant");
            }

        }


        [Command("matchday")]
        [Summary("Get matches of the day")]
        public async Task matchday(string competition = null)
        {
            try
            {
                String result;
                WebClient client = new WebClient();
                string address = "";
                if(competition == null)
                {
                    address = @"https://api.football-data.org/v2/matches";
                }
                else
                {
                    address = @"https://api.football-data.org/v2/matches?competitions=" + competition;
                }
                client.Headers.Add("X-Auth-Token", "your token");
                result = client.DownloadString(address);
                var data = JsonConvert.DeserializeObject<RootObjectMatchDay>(result);
                string played = "Matchs ayant déjà été joués aujourd'hui : \n\n";
                string notyet = "Prochainement : \n\n";
                foreach (MatchDay match in data.matches)
                {
                    if (match.score.fullTime.homeTeam == null)
                    {
                        notyet += match.utcDate.ToString("HH:mm") + " : " + match.homeTeam.name + " - " + match.awayTeam.name + " \n";
                    }
                    else
                    {
                        played += match.homeTeam.name + " " + match.score.fullTime.homeTeam + " - " + match.score.fullTime.awayTeam + " " + match.awayTeam.name + " \n";

                    }
                }
                await ReplyAsync(played+"\n"+notyet);
            }
            catch (Exception e)
            {
                await ReplyAsync("Veuillez entrer un championnat existant");
            }
}
    

    }
}



