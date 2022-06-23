using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Reddit;
using Reddit.Controllers;
using Reddit.Controllers.EventArgs;

namespace DootBot2.Commands
{
    class RedditStuff : BaseCommandModule
    {
        [Command("Cats")]
        [Description("Cats")]
        public async Task Reddit(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var reddit = new RedditClient(appId: API_keys.redditAppID, appSecret: API_keys.redditAppSecret, refreshToken: API_keys.redditRefreshToken);

            var postStr = "";
            var cats = reddit.Subreddit("cats").About();
            var catposts = cats.Posts.Top;

            foreach (var posts in catposts)
            {
                postStr += posts;
            }

            Console.WriteLine(catposts);

            await ctx.RespondAsync("Command Worked!").ConfigureAwait(false);

        }

    }
}
