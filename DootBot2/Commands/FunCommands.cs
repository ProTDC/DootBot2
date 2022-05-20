using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using OpenWeatherMap;
using DSharpPlus;

namespace DootBot2.Commands

{
    class FunCommands : BaseCommandModule
    {

        [Command("Porn")]
        [Description("Displays porn")]
        public async Task Porn(CommandContext ctx)
        {
            await ctx.RespondAsync("Degenerates like you, belong on a cross").ConfigureAwait(false);
            Console.WriteLine("Command worked");
            return;
        }

        [Command("Motivation")]
        [Description("Displays motivation to keep on going")]
        public async Task Motivation(CommandContext ctx)
        {

            Random rand = new Random();

            if (rand.Next() > (Int32.MaxValue / 2))
                await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/424874562082045962/811358442786390056/Motivational_Lizard.mp4").ConfigureAwait(false);
            else
                await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/967031855985590383/971717012978036796/kys.mov").ConfigureAwait(false);
            return;
        }

        [Command("Celebrate")]
        [Aliases("Celebration")]
        [Description("Celebration")]
        public async Task Celebration(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/634063767466147840/971711431902908496/trim.E9946223-78D6-454C-867F-627BBF29429B.mov").ConfigureAwait(false);
            return;
        }

        [Command("Oljefondet")]
        [Description("Displays the market value of Oljefondet")]
        public async Task Oljefondet(CommandContext ctx)
        {

            using WebClient web1 = new WebClient();
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://www.nbim.no/no/oljefondet/markedsverdi/");
            var datalist = document.DocumentNode.SelectNodes("//div[@class='section__article-fund__inner']");

            foreach (var content in datalist)
            {
                await ctx.Channel.SendMessageAsync(content.InnerText);
            }
            Console.Read();
            return;
        }

        [Command("Avatar")]
        [Description("Displays your avatar")]
        public async Task Avatar(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.SendMessageAsync(member.DisplayName + "s avatar: " + member.AvatarUrl);
            return;
        }

        [Command("Activity")]
        [Description("Displays a users status or activity")]
        public async Task Status(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.SendMessageAsync(member.DisplayName + "s activity is currently: " + member.Presence.Activity);
            return;
        }

        [Hidden]
        [Command("setactivity")]
        private async Task Setactivity(CommandContext ctx)
        {
            if (ctx.User.Id == 461446979155918859)
            {
                DiscordActivity activity = new DiscordActivity();
                DiscordClient discord = ctx.Client;
                string input = Console.ReadLine();
                activity.Name = input;
                await discord.UpdateStatusAsync(activity);
                return;
            }
            else
            {
                return;
            }
        }

        [Command("pepe"), Aliases("feelsbadman"), Description("Feels bad, man.")]
        public async Task Pepe(CommandContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = "Pepe",
                ImageUrl = "http://i.imgur.com/44SoSqS.jpg"
            };
            await ctx.RespondAsync(embed);
            return;
        }

        [Command("RPS")]
        [Description("Starts a game of rock paper scissors against me")]
        public async Task RPS(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            await ctx.Channel.SendMessageAsync("Respond with either Rock, Paper or Scissors").ConfigureAwait(false);

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            Random r = new Random();
            int computerChoice = r.Next(4);

            if (computerChoice == 1)
            {
                if (message.Result.Content.ToLower().Contains("rock")) 
                {
                    await ctx.Channel.SendMessageAsync("i chose Rock");
                    await ctx.Channel.SendMessageAsync("its a tie");
                    return;
                }

                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Paper");
                    await ctx.Channel.SendMessageAsync("Its a tie ");
                    return;
                }
                else if (message.Result.Content.ToLower().Contains("scissors"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Scissors");
                    await ctx.Channel.SendMessageAsync("Its a tie ");
                    return;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };

            if (computerChoice == 2) 
            {
                if (message.Result.Content.ToLower().Contains("rock"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Paper");
                    await ctx.Channel.SendMessageAsync("You lose dumbass");
                    return;
                }

                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Scissors");
                    await ctx.Channel.SendMessageAsync("You lose dumbass");
                    return;

                }
                else if (message.Result.Content.ToLower().Contains("scissors"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Rock");
                    await ctx.Channel.SendMessageAsync("you lose dumbass");
                    return;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };

            if (computerChoice == 3) 
            {
                if (message.Result.Content.ToLower().Contains("rock"))
                {
                    await ctx.Channel.SendMessageAsync("i chose scissors");
                    await ctx.Channel.SendMessageAsync("God fucking damn it you won");
                    return;
                }


                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Rock");
                    await ctx.Channel.SendMessageAsync("God fucking damn it you won");
                    return;

                }
                else if (message.Result.Content.ToLower().Contains ("scissors"))
                {
                    await ctx.Channel.SendMessageAsync("i chose Paper");
                    await ctx.Channel.SendMessageAsync("God fucking damn it you won");
                    return;
                }
                else
                {
                    await ctx.Channel.SendMessageAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };
        }

        [Command("Poll")]
        public async Task Poll(CommandContext ctx, TimeSpan duration, params DiscordEmoji[] emojiOptions)
        {
            var interactivity = ctx.Client.GetInteractivity();
            var options = emojiOptions.Select(x => x.ToString());

            var embed = new DiscordEmbedBuilder
            {
                Title = "Poll",
                Description = string.Join("", options)
            };

            var pollMessage = await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);

            foreach (DiscordEmoji option in emojiOptions)
            {
                await pollMessage.CreateReactionAsync(option).ConfigureAwait(false);
            }

            var result = await interactivity.CollectReactionsAsync(pollMessage, duration).ConfigureAwait(false);
            var distinctResult = result.Distinct();
            var results = distinctResult.Select(x => $"{x.Emoji}: {x.Total}");


            await ctx.Channel.SendMessageAsync(string.Join("\n", results)).ConfigureAwait(false);
        }
    }

}

