using System.Threading.Tasks;

namespace BotDiscord.ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            await Startup.RunAsync(args);
        }
    }
}
