using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Reddit.Controllers.EventArgs;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Steam;
using SteamWebAPI2;
using SteamWebAPI2.Utilities;
using SteamWebAPI2.Interfaces;
using System.Net.Http;

namespace DootBot2.Commands
{
    class SteamStuff : BaseCommandModule
    {
        [Command("Games")]
        public async Task Games(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var webInterfaceFactory = new SteamWebInterfaceFactory(API_keys.steamAPIKey);
            var steamInterface = webInterfaceFactory.CreateSteamWebInterface<SteamStore>(new HttpClient());

            Console.WriteLine(steamInterface.ToString());


        }
    }
}
