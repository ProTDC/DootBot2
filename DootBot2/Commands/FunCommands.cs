﻿using DSharpPlus.CommandsNext;
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
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

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
            await ctx.Channel.TriggerTypingAsync();

            await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/634063767466147840/971711431902908496/trim.E9946223-78D6-454C-867F-627BBF29429B.mov").ConfigureAwait(false);
            return;
        }

        [Command("Oljefondet")]
        [Description("Displays the market value of Oljefondet")]
        public async Task Oljefondet(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            using WebClient web1 = new WebClient();
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load("https://www.nbim.no/no");
            var datalist = document.DocumentNode.SelectNodes("//div[@class='page-title']");

            foreach (var content in datalist)
            {
                await ctx.Channel.SendMessageAsync(content.InnerText).ConfigureAwait(false);
            }
            return;
        }

        private static readonly HttpClient httpClient = new HttpClient();
        [Command("Movie")]
        [Description("Displays a movie")]
        public async Task Movie(CommandContext ctx)
        {
            var key = "k_0w44lid6";
            var title = "Cats".ToLower();
            var type = "SearchTitle";
            HttpResponseMessage response = await httpClient.GetAsync($"http://www.imdb-api.com/en/API/{type}/{key}/{title}");
            var content = await response.Content.ReadAsStringAsync();
            //Console.WriteLine(content);
            var array = content.Replace("{", "").Replace("}", "").Split(",");
                                        //remove comments to remove the type things
            var searchType = array[0];  //.Split(":")[1].Replace('"', ' ');
            var expression = array[1];  //.Split(":")[1].Replace('"', ' ');
            var results = array[2];     //.Split(":")[1].Replace('"', ' ');
            var errorMessage = array[3];//.Split(":")[1].Replace('"', ' ');
            Console.WriteLine(searchType);
            Console.WriteLine(expression);
            Console.WriteLine(results);
            Console.WriteLine(errorMessage);
            //await ctx.RespondAsync(embed).ConfigureAwait(false);
            return;
        }


        [Command("Arebirdsreal")]
        [Description("Tells you if birds are real or not")]
        public async Task Birb(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            await ctx.Channel.SendMessageAsync("No").ConfigureAwait(false);
        }

        [Command("RPS")]
        [Description("Starts a game of rock paper scissors against me")]
        public async Task RPS(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            await ctx.Channel.SendMessageAsync("Respond with either Rock, Paper or Scissors").ConfigureAwait(false);

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            int playerChoice;
            string playerChoiceStr;
            switch (message.Result.Content.ToLower()) {
                case "rock":
                    playerChoice = 1;
                    break;
                case "paper":
                    playerChoice = 2;
                    break;
                case "scissors":
                    playerChoice = 3;
                    break;
                default:
                    await ctx.Channel.SendMessageAsync("Invalid response").ConfigureAwait(false);
                    return;
            }
            Random r = new Random();
            int computerChoice = r.Next(4);
            if (computerChoice == playerChoice) {
                await ctx.Channel.SendMessageAsync("It's a tie!").ConfigureAwait(false);
                return;
            }
            if (computerChoice == 1 && playerChoice == 2 || computerChoice == 2 && playerChoice == 3 || computerChoice == 3 && playerChoice == 1) {
                await ctx.Channel.SendMessageAsync("You win!").ConfigureAwait(false);
                return;
            }
            await ctx.Channel.SendMessageAsync("I win!").ConfigureAwait(false);
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

    }

}

