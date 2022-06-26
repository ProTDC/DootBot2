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
using System.Collections.Generic;

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
            var random = new Random();
            var url = new List<string> { "" };

            IDictionary<string, IList<Post>> Posts = new Dictionary<string, IList<Post>>();
            foreach (Post post in reddit.Subreddit("cats").Posts.New)
            {
                if (!Posts.ContainsKey(post.Subreddit))
                {
                    Posts.Add(post.Subreddit, new List<Post>());
                }
                Posts[post.Subreddit].Add(post);

                url.Add(post.Listing.URL + " ");
            }

            int index = random.Next(url.Count);
            Console.WriteLine(url[index]);

            await ctx.RespondAsync(url[index]).ConfigureAwait(false);


        }

    }
}
