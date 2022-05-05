using DootBot2.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using DootBot2;
using Discord.Audio;
using DSharpPlus.Entities;

namespace Dootbot2
{

    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; } 
        public VoiceNextExtension Voice { get; set; }


        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(5)
            });

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = false
            };

            var flagBritish = DiscordEmoji.FromName(Client, ":flag_gb:");
            var skull = DiscordEmoji.FromName(Client, ":skull:");
            var trumpet = DiscordEmoji.FromName(Client, ":trumpet:");
            var letterD = DiscordEmoji.FromName(Client, ":regional_indicator_d:");
            var letterO = DiscordEmoji.FromName(Client, ":regional_indicator_o:");
            var lettero2 = DiscordEmoji.FromName(Client, ":o2:");
            var letterT = DiscordEmoji.FromName(Client, ":regional_indicator_t:");
            var vomit = DiscordEmoji.FromName(Client, ":face_vomiting:");

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("doot"))
                {
                    await e.Message.RespondAsync("Doot");
                    //await e.Message.CreateReactionAsync(letterD);
                    //await e.Message.CreateReactionAsync(letterO);
                    //await e.Message.CreateReactionAsync(lettero2);
                    //await e.Message.CreateReactionAsync(letterT);
                }

            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("Fuck you"))
                {
                    await e.Message.RespondAsync("fuck you too");
                }

            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("bitch"))
                {
                    await e.Message.RespondAsync("Bitch");
                }

            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("british") || e.Message.Content.Contains("bri'ish") || e.Message.Content.Contains("briish"))
                {
                    await e.Message.RespondAsync("BRi'ISH! ??!");
                    //await e.Message.CreateReactionAsync(flagBritish);
                }
            };

            //Client.MessageCreated += async (s, e) =>
            //{
            //    if (e.Message.Content.Contains("fortnite") || e.Message.Content.Contains("valorant") & e.Message.Content.Contains("overwatch") || e.Message.Content.Contains("genshin"))
            //    {
            //        await e.Message.CreateReactionAsync(vomit);
            //    }
            //};

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.Contains("brunost") || e.Message.Content.Contains("Brunost") & e.Message.Content.Contains("brun ost") || e.Message.Content.Contains("Brun ost"))
                {
                    await e.Message.RespondAsync("https://tenor.com/view/norway-brown-cheese-cheese-norwegian-brown-cheese-ragnarocka-gif-23473349");
                }
            };

            Client.MessageDeleted += async (s, e) =>
            {
                await e.Message.RespondAsync(e.Message.Author.Mention + " https://tenor.com/view/delete-i-saw-that-i-saw-delete-message-i-see-gif-22475145");
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<VoiceCommands>();
            Commands.RegisterCommands<Memes>();

            //Voice = Client.UseVoiceNext();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

    }
}
