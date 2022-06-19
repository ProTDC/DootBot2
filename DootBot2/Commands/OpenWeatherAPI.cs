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

        [Command("Test")]
        [Description("Displays the weather")]
        public async Task Weather(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var api_key = "9d188c20db14b2c172229bafe1db9d9c";
            var city = "Oslo";
            HttpResponseMessage response = await httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}");
            var content = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(content);

            foreach(var e in json)
            {
                Console.WriteLine(e);
            }

            return;

        }
    }
}
