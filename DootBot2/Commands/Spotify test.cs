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
using SpotifyAPI.Web;

namespace DootBot2.Commands
{
    class Spotify_test : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();

        [Command("test")]
        public async Task test(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            string combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            //var config = SpotifyClientConfig.CreateDefault().WithAuthenticator(new ClientCredentialsAuthenticator("e352f0b13dff4a798d52df0d28f447e5", "0acfaf58cbc149938eef3a8dae3915eb"));
            //var spotify = new SpotifyClient(config);

            HttpResponseMessage gameResponse = await httpClient.GetAsync($"https://api.spotify.com/v1/search?type=track&include_external=audio");
            var gameContent = await gameResponse.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(gameContent);

            Console.WriteLine(gameResponse);

            return;
        }
    }
}
