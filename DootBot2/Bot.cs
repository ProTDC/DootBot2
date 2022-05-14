using DootBot2.Commands;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.VoiceNext;
using DootBot2;
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
                EnableDms = true,
                EnableMentionPrefix = true,
                DmHelp = false,
                IgnoreExtraArguments = false,
                UseDefaultCommandHandler = true
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
                if (e.Message.Author.IsBot)
                {
                    return;
                }

                if (e.Message.Content.ToLower().Contains("doot"))
                {
                    await e.Message.RespondAsync("Doot").ConfigureAwait(false);

                    await e.Message.CreateReactionAsync(letterD).ConfigureAwait(false);
                    await e.Message.CreateReactionAsync(letterO).ConfigureAwait(false);
                    await e.Message.CreateReactionAsync(lettero2).ConfigureAwait(false);
                    await e.Message.CreateReactionAsync(letterT).ConfigureAwait(false);
                    return;
                }

            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Author.IsBot)
                {
                    return;
                }

                if (e.Message.Content.ToLower().Contains("fuck you"))
                {
                    await e.Message.RespondAsync("fuck you too").ConfigureAwait(false);
                    return;
                }
            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Author.IsBot)
                {
                    return;
                }

                if (e.Message.Content.ToLower().Contains("bitch"))
                {
                    await e.Message.RespondAsync("Bitch").ConfigureAwait(false);
                    return;
                }

            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Author.IsBot)
                {
                    return;
                }

                if (e.Message.Content.ToLower().Contains("british") || e.Message.Content.ToLower().Contains("bri'ish") || e.Message.Content.ToLower().Contains("briish"))
                {
                    await e.Message.RespondAsync("BRi'ISH! ??!").ConfigureAwait(false);
                    await e.Message.CreateReactionAsync(flagBritish).ConfigureAwait(false);
                    return;
                }
            };

            //Client.MessageCreated += async (s, e) =>
            //{
            //    if (e.Message.Author.IsBot)
            //    {
            //        return;
            //    }

            //    if (e.Message.Author.Id.Equals(373135474119933955))
            //    {
            //        await e.Message.RespondAsync("stfu tom").ConfigureAwait(false);
            //        return;
            //    }
            //};

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().Contains("fortnite") || e.Message.Content.ToLower().Contains("valorant") || e.Message.Content.ToLower().Contains("overwatch") || e.Message.Content.ToLower().Contains("genshin"))
                {
                    await e.Message.CreateReactionAsync(vomit);
                    return;
                }
            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().Contains("brunost") || e.Message.Content.ToLower().Contains("brun ost"))
                {
                    await e.Message.RespondAsync("https://tenor.com/view/norway-brown-cheese-cheese-norwegian-brown-cheese-ragnarocka-gif-23473349").ConfigureAwait(false);
                    return;
                }
            };

            Client.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().Contains("forgor"))
                {
                    await e.Message.CreateReactionAsync(skull).ConfigureAwait(false);
                    return;
                }
            };

            Client.MessageDeleted += async (s, e) =>
            {
                await e.Message.RespondAsync(e.Message.Author.Mention + " https://tenor.com/view/delete-i-saw-that-i-saw-delete-message-i-see-gif-22475145").ConfigureAwait(false);
                return;
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<Memes>();
            Commands.RegisterCommands<RedditStuff>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

 
        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

    }
}