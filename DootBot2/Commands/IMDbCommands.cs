﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IMDbApiLib;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DootBot2.Commands
{
    class IMDbCommands : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();
        [Command("Movie")]
        [Description("Displays a movie")]
        public async Task Movie(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            var combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            Console.WriteLine(combinedMessage);

            var key = "k_0w44lid6";
            var title = combinedMessage;
            var type = "SearchTitle";
            HttpResponseMessage response = await httpClient.GetAsync($"http://www.imdb-api.com/en/API/{type}/{key}/{title}");
            var content = await response.Content.ReadAsStringAsync();

            var array = content.Replace("{", "").Replace("}", "").Split(",");

            var searchType = array[0];
            var expression = array[1];
            var results = array[2];
            var errorMessage = array[3];

            var id = content.Split("id\":\"")[1].Split("\"")[0];

            var apiLib = new ApiLib(key);
            var ratingData = await apiLib.RatingsAsync(id);
            var movieData = await apiLib.TitleAsync(id);

            var embed = new DiscordEmbedBuilder
            {
                Title = ratingData.FullTitle,
                Description = movieData.Plot,
                ImageUrl = movieData.Image,
            };
            embed.AddField("Director", movieData.Directors);

            string actstr = string.Empty;
            var acting = movieData.ActorList;
            foreach (var act in acting)
            {
                actstr += act.Name + ", ";
            }
            embed.AddField("Actors", actstr);

            embed.AddField("Genres", movieData.Genres);
            embed.AddField("IMDB ", ratingData.IMDb + "/10");
            embed.AddField("Metacritic ", ratingData.Metacritic + "%");
            embed.AddField("Rotten Tomatoes ", ratingData.RottenTomatoes + "%");

            Console.WriteLine(searchType);
            Console.WriteLine(expression);
            Console.WriteLine(results);
            Console.WriteLine(errorMessage);
            await ctx.RespondAsync(embed).ConfigureAwait(false);
            return;
        }
    }
}
