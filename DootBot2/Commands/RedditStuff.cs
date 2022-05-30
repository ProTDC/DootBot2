using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Reddit;

namespace DootBot2.Commands
{
    class RedditStuff : BaseCommandModule
    {
        public RedditClient Reddit { get; private set;}

        //[Command("Cats")]
        //[Description("Displays a picture of a cat")]
        //public async Task Cats(CommandContext ctx)
        //{
        //    var cats = Reddit.Subreddit();
        //    await ctx.Channel.SendMessageAsync().ConfigureAwait(false);
        //}
    }
}
