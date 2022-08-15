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
using IMDbApiLib;
using IMDbApiLib.Models;
using System.Net.Http;

namespace DootBot2.Commands

{
    class FunCommands : BaseCommandModule
    {
        [Command("Motivation")]
        [Description("Displays motivation to keep on going")]
        public async Task Motivation(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            Random rand = new Random();

            if (rand.Next() > (Int32.MaxValue / 2))
                await ctx.RespondAsync("https://cdn.discordapp.com/attachments/424874562082045962/811358442786390056/Motivational_Lizard.mp4").ConfigureAwait(false);
            else
                await ctx.RespondAsync("https://cdn.discordapp.com/attachments/967031855985590383/971717012978036796/kys.mov").ConfigureAwait(false);
            return;
        }

        [Command("Celebrate")]
        [Aliases("Celebration")]
        [Description("Celebration")]
        public async Task Celebration(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            await ctx.RespondAsync("https://cdn.discordapp.com/attachments/634063767466147840/971711431902908496/trim.E9946223-78D6-454C-867F-627BBF29429B.mov").ConfigureAwait(false);
            return;
        }

        [Command("Arebirdsreal")]
        [Description("Tells you if birds are real or not")]
        public async Task Birb(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            await ctx.RespondAsync("No").ConfigureAwait(false);
        }

        [Command("RPS")]
        [Description("Starts a game of rock paper scissors against me")]
        public async Task RPS(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            await ctx.RespondAsync("Respond with either Rock, Paper or Scissors").ConfigureAwait(false);

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            Random r = new Random();
            int computerChoice = r.Next(4);

            if (computerChoice == 1)
            {
                if (message.Result.Content.ToLower().Contains("rock")) 
                {
                    await ctx.RespondAsync("i chose Rock");
                    await ctx.RespondAsync("its a tie");
                    return;
                }

                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.RespondAsync("i chose Paper");
                    await ctx.RespondAsync("Its a tie ");
                    return;
                }
                else if (message.Result.Content.ToLower().Contains("scissors"))
                {
                    await ctx.RespondAsync("i chose Scissors");
                    await ctx.RespondAsync("Its a tie ");
                    return;
                }
                else
                {
                    await ctx.RespondAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };

            if (computerChoice == 2) 
            {
                if (message.Result.Content.ToLower().Contains("rock"))
                {
                    await ctx.RespondAsync("i chose Paper");
                    await ctx.RespondAsync("You lose dumbass");
                    return;
                }

                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.RespondAsync("i chose Scissors");
                    await ctx.RespondAsync("You lose dumbass");
                    return;

                }
                else if (message.Result.Content.ToLower().Contains("scissors"))
                {
                    await ctx.RespondAsync("i chose Rock");
                    await ctx.RespondAsync("you lose dumbass");
                    return;
                }
                else
                {
                    await ctx.RespondAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };

            if (computerChoice == 3) 
            {
                if (message.Result.Content.ToLower().Contains("rock"))
                {
                    await ctx.RespondAsync("i chose scissors");
                    await ctx.RespondAsync("God fucking damn it you won");
                    return;
                }


                else if (message.Result.Content.ToLower().Contains("paper"))
                {
                    await ctx.RespondAsync("i chose Rock");
                    await ctx.RespondAsync("God fucking damn it you won");
                    return;

                }
                else if (message.Result.Content.ToLower().Contains ("scissors"))
                {
                    await ctx.RespondAsync("i chose Paper");
                    await ctx.RespondAsync("God fucking damn it you won");
                    return;
                }
                else
                {
                    await ctx.RespondAsync("You must choose Rock, Paper or Scissors! Please try again!");
                }
            };
        }

        [Command("Poll")]
        public async Task Poll(CommandContext ctx, TimeSpan duration, params DiscordEmoji[] emojiOptions)
        {
            await ctx.Channel.TriggerTypingAsync();

            var interactivity = ctx.Client.GetInteractivity();
            var options = emojiOptions.Select(x => x.ToString());

            var embed = new DiscordEmbedBuilder
            {
                Title = "Poll",
                Description = string.Join("", options)
            };

            var pollMessage = await ctx.RespondAsync(embed: embed).ConfigureAwait(false);

            foreach (DiscordEmoji option in emojiOptions)
            {
                await pollMessage.CreateReactionAsync(option).ConfigureAwait(false);
            }

            var result = await interactivity.CollectReactionsAsync(pollMessage, duration).ConfigureAwait(false);
            var distinctResult = result.Distinct();
            var results = distinctResult.Select(x => $"{x.Emoji}: {x.Total}");


            await ctx.RespondAsync(string.Join("\n", results)).ConfigureAwait(false);
        }

        //[Command("Return")]
        //[Description("Leaves then returns to server")]
        //public async Task Return(CommandContext ctx)
        //{
        //}


        [Hidden]
        [Command("Repeat")]
        [Description("Classified")]
        public async Task Repeat(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            var interactivity = ctx.Client.GetInteractivity();
            var chnlsend = ctx.Guild.GetChannel(981805613732483082);

            var message = await interactivity.WaitForMessageAsync(x => x.Channel.Name.ToLower().Contains("spam"));

            await chnlsend.SendMessageAsync(message.Result.Content);

            await ctx.Channel.DeleteMessageAsync(ctx.Message);
            await ctx.Channel.DeleteMessageAsync(message.Result);
        }

        //[Command("test")]
        //public async Task Test(CommandContext ctx, DiscordMember member)
        //{
        //    var activity = member.Presence.Activities;
        //    var activityString = string.Empty;

        //    //Console.WriteLine(member.Presence.Activity.ActivityType.ToString());

        //    //foreach(var act in activity)
        //    //{
        //    //    Console.WriteLine(act);
        //    //}

        //    foreach(var act in activity)
        //    {
        //        Console.WriteLine(act.Name);
        //    }

        //    await ctx.RespondAsync("it worked (i think)").ConfigureAwait(false);

        //}

    }

}

