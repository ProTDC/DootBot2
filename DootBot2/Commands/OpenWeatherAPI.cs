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

namespace DootBot2.Commands
{
    class OpenWeatherAPI : BaseCommandModule
    {
        [Command("Test")]
        [Description("Displays the weather")]
        public async Task Weather(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/weather?q=London%2Cuk"),
                Headers =
    {
        { "X-RapidAPI-Key", "63c9ed964amsh68af60425a81dc8p1db100jsn132acf8d498f" },
        { "X-RapidAPI-Host", "community-open-weather-map.p.rapidapi.com" },
    },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            await ctx.RespondAsync(body);

        }
    }
}
