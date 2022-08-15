using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using SpotifyAPI.Web;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace DootBot2.Commands
{
    class VoiceCommands : BaseCommandModule
    {
        [Command("join")]
        [Description("joins the current voice chat the author is connected to")]
        public async Task JoinCommand(CommandContext ctx, DiscordChannel channel = null)
        {
            channel ??= ctx.Member.VoiceState?.Channel;
            await channel.ConnectAsync();
        }

        [Command("play")]
        [Description("plays music to the connected voice chat")]
        public async Task PlayCommand(CommandContext ctx, string input)
        {
            string path = @"C:\Users\protd\Pictures\music\" + input;
            var vnext = ctx.Client.GetVoiceNext();
            var connection = vnext.GetConnection(ctx.Guild);

            var transmit = connection.GetTransmitSink();

            var pcm = ConvertAudioToPcm(path);
            await pcm.CopyToAsync(transmit);
            await pcm.DisposeAsync();
        }

        [Command("leave")]
        [Description("leaves the current voice chat")]
        public async Task LeaveCommand(CommandContext ctx)
        {
            var vnext = ctx.Client.GetVoiceNext();
            var connection = vnext.GetConnection(ctx.Guild);

            connection.Disconnect();
        }

        private Stream ConvertAudioToPcm(string filePath)
        {
            var ffmpeg = Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $@"-i ""{filePath}"" -ac 2 -f s16le -ar 48000 pipe:1",
                RedirectStandardOutput = true,
                UseShellExecute = false
            });

            return ffmpeg.StandardOutput.BaseStream;
        }
    }
}
