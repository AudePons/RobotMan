using Discord.Commands;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using BotDiscord.ConsoleApp.Classes.Weather;

namespace BotDiscord.ConsoleApp.Modules
{
    [Name("Weather")]
    [Summary("Weather of your city")]
    public class WeatherModule : ModuleBase<SocketCommandContext>
    {
        [Command("weather")]
        [Summary("Get the weather of your city")]
        public async Task weather(string city)
        {
            try
            {
                String result;
                WebClient client = new WebClient();
                String address = @"http://api.openweathermap.org/data/2.5/weather?q="+city+"&APPID=96c5413343267d933f6640af713ba097";
                result = client.DownloadString(address);
                var data = JsonConvert.DeserializeObject<RootObject>(result);
                string temperature = (data.main.temp - 273.15).ToString();
                await ReplyAsync("A "+city+", il fait "+temperature+" °C"); 
           
            }
            catch (Exception e)
            {
                await ReplyAsync("Veuillez entrer une ville existante");
            }
            
        }

        

        

        

        

        

        

        


    }
}



