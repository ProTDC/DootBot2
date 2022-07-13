using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IMDbApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DootBot2.Commands
{
    class IMDbCommands : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();
        [Command("Movie")]
        [Description("Displays information about a movie from IMDb")]
        public async Task Movies(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            var combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            var key = API_keys.IMDbKey;
            var title = combinedMessage;
            var type = "SearchTitle";
            HttpResponseMessage response = await httpClient.GetAsync($"http://www.imdb-api.com/en/API/{type}/{key}/{title}");
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.StatusCode);


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

            embed.AddField("ID", movieData.Id);

            embed.AddField("Director", movieData.Directors);

            string actstr = string.Empty;
            var acting = movieData.ActorList;
            foreach (var act in acting)
            {
                actstr += act.Name + ", ";
            }
            embed.AddField("Actors", actstr);
            embed.AddField("Writers", movieData.Writers);
            embed.AddField("Genres", movieData.Genres);
            embed.AddField("Runtime", movieData.RuntimeStr);
            embed.AddField("Budget", movieData.BoxOffice.Budget);
            embed.AddField("Box office", movieData.BoxOffice.CumulativeWorldwideGross);
            embed.AddField("Rating", movieData.ContentRating);
            embed.AddField("Awards", movieData.Awards);
            embed.AddField("IMDB Rating ", ratingData.IMDb + "/10");
            embed.AddField("Metacritic ", ratingData.Metacritic + "%");
            embed.AddField("Rotten Tomatoes ", ratingData.RottenTomatoes + "%");

            await ctx.RespondAsync(embed).ConfigureAwait(false);

            //Console.WriteLine(searchType);
            //Console.WriteLine(expression);
            //Console.WriteLine(results);
            //Console.WriteLine(errorMessage);
            return;
        }

        [Command("Series")]
        [Description("Displays a series from IMDb")]
        public async Task Series(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            var combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            var key = API_keys.IMDbKey;
            var title = combinedMessage;
            var type = "SearchTitle";
            HttpResponseMessage response = await httpClient.GetAsync($"http://www.imdb-api.com/en/API/{type}/{key}/{title}");
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(response.StatusCode);

            var array = content.Replace("{", "").Replace("}", "").Split(",");

            var id = content.Split("id\":\"")[1].Split("\"")[0];

            var apiLib = new ApiLib(key);
            var ratingData = await apiLib.RatingsAsync(id);
            var seriesData = await apiLib.TitleAsync(id);

            var embed = new DiscordEmbedBuilder
            {
                Title = ratingData.FullTitle,
                Description = seriesData.Plot,
                ImageUrl = seriesData.Image,
            };

            embed.AddField("Creators", seriesData.TvSeriesInfo.Creators);

            string actstr = string.Empty;
            var acting = seriesData.ActorList;
            foreach (var act in acting)
            {
                actstr += act.Name + ", ";
            }
            embed.AddField("Actors", actstr);
            embed.AddField("Seasons", seriesData.TvSeriesInfo.Seasons.Count.ToString());
            embed.AddField("Ended in", seriesData.TvSeriesInfo.YearEnd);
            embed.AddField("Awards", seriesData.Awards);
            embed.AddField("IMDb rating", seriesData.IMDbRating + "/10");
            embed.AddField("Metacritic", ratingData.Metacritic + "%");
            embed.AddField("Rotten Tomatoes", ratingData.RottenTomatoes + "%");

            await ctx.RespondAsync(embed).ConfigureAwait(false);
            return;
        }
    }
}