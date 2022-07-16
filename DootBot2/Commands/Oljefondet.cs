using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DootBot2.Commands 
{
    class Oljefondet : BaseCommandModule
    {
        static readonly HttpClient httpClient = new HttpClient();

        [Command("Oljefondet")]
        [Description("Displays the market value of Oljefondet")]
        public async Task OljefondetVerdi(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            HttpResponseMessage Response = await httpClient.GetAsync($"https://www.nbim.no/LiveNavHandler/Current.ashx?l=en-GB&t=1657634463553&PreviousNavValue=12005458800555&key=263c30dd-d5ba-41d6-a9b1-c1fb59cf30da");
            var Content = await Response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(Content);
            Console.WriteLine(Response.StatusCode);

            await ctx.RespondAsync($"Oljefondets markedsverdi er {json["Value"].ToString()}kr").ConfigureAwait(false);
        } 
    }
}
