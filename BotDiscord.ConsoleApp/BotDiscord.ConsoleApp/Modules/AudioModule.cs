using System.Threading.Tasks;
using BotDiscord.ConsoleApp.Services;
using Discord;
using Discord.Commands;


namespace BotDiscord.ConsoleApp.Modules
{
    [Name("Audio")]
    [Summary("Listen music")]
    public class AudioModule : ModuleBase<SocketCommandContext>
    {
        private readonly AudioService _service;

        public AudioModule(AudioService service)
        {
            _service = service;
        }

        [Command("join")]
        [Summary("Bot join the tchat")]
        public async Task JoinCmd()
        {
            await _service.JoinAudio(Context.Guild, (Context.User as IVoiceState).VoiceChannel);
        }

        [Command("leave")]
        [Summary("Bot leave the tchat")]
        public async Task LeaveCmd()
        {
            await _service.LeaveAudio(Context.Guild);
        }

        [Command("play")]
        [Summary("Bot plays music")]
        public async Task PlayCmd([Remainder] string song)
        {
            await _service.SendAudioAsync(Context.Guild, Context.Channel, song);
        }
    }
}
