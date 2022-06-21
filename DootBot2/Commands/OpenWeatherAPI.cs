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

namespace DootBot2.Commands
{
    class OpenWeatherAPI : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();

        [Command("Weather")]
        [Description("Displays the weather")]
        public async Task Weather(CommandContext ctx, string message)
        {
            await ctx.TriggerTypingAsync();

            var api_key = API_keys.WeatherKey;
            var city = message;
            HttpResponseMessage response = await httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}");
            var content = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(content);

            foreach(var e in json)
            {
                Console.WriteLine(e);
            }

            if (response.IsSuccessStatusCode == false)
            {
                await ctx.RespondAsync("Please provide a valid city").ConfigureAwait(false);
                return;
            }
            else
            {
                var embed = new DiscordEmbedBuilder()
                {
                    Title = json["name"].ToString(),
                    Description = "Country: " + json["sys"]["country"].ToString()
                };
                embed.AddField("Weather: " + json["weather"][0]["main"].ToString(), json["weather"][0]["description"].ToString());
                embed.AddField("Wind", json["wind"]["speed"].ToString() + "m/s");
                embed.AddField("Humidity", json["main"]["humidity"].ToString() + "%");
                embed.AddField("Coordinates", $"{json["coord"]["lon"].ToString()}, {json["coord"]["lat"].ToString()}");

                await ctx.RespondAsync(embed).ConfigureAwait(false);
                return;
            }

        }
    }
}
