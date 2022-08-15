using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using OpenWeatherMap;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace DootBot2.Commands
{
    class SteamStuff : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();

        [Command("Game")]
        [Description("Displays information about a game from steam")]
        public async Task Games(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            string combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            var api_key = API_keys.steamAPIKey2;
            var title = combinedMessage;

            HttpResponseMessage gameResponse = await httpClient.GetAsync($"https://api.isthereanydeal.com/v01/game/info/?key={api_key}&plains={title}&optional=metacritic");
            var gameContent = await gameResponse.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(gameContent);
            //Console.WriteLine(json);

            HttpResponseMessage priceResponse = await httpClient.GetAsync($"https://api.isthereanydeal.com/v01/game/prices/?key={api_key}&plains={title}&region=us&country=us&shops=steam");
            var priceContent = await priceResponse.Content.ReadAsStringAsync();
            JObject json2 = JObject.Parse(priceContent);
            //Console.WriteLine(json2);

            Console.WriteLine(gameResponse.StatusCode);
            Console.WriteLine(priceResponse.StatusCode);

            if (gameResponse.IsSuccessStatusCode == false)
            {
                await ctx.RespondAsync("Please provide a valid game").ConfigureAwait(false);
                return;
            }
            else
            {
                var embed = new DiscordEmbedBuilder()
                {
                    Title = json["data"][title]["title"].ToString(),
                    Description = json["data"][title]["metacritic"]["summary"].ToString(),
                    ImageUrl = json["data"][title]["image"].ToString()
                };

                embed.AddField("Steam Score", json["data"][title]["reviews"]["steam"]["text"].ToString());
                embed.AddField("Metacritic", json["data"][title]["metacritic"]["critic_score"].ToString() + "%");
                embed.AddField("Price", json2["data"][title]["list"][0]["price_new"].ToString() + "£");

                await ctx.RespondAsync(embed).ConfigureAwait(false);
                return;
            }


        }
    }
}
