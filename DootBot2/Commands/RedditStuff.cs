﻿using DSharpPlus.CommandsNext;
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
using Newtonsoft.Json.Linq;

namespace DootBot2.Commands
{
    class RedditStuff : BaseCommandModule
    {
        [Command("Cats")]
        [Aliases("Cat")]
        [Description("Displays a picture of cats picked from r/catpics")]
        public async Task Cat(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var reddit = new RedditClient(appId: API_keys.redditAppID, appSecret: API_keys.redditAppSecret, refreshToken: API_keys.redditRefreshToken);
            var random = new Random();
            var url = new List<string> { "" };

            IDictionary<string, IList<Post>> Posts = new Dictionary<string, IList<Post>>();
            foreach (Post post in reddit.Subreddit("catpics").Posts.Top)
            {
                if (!Posts.ContainsKey(post.Subreddit))
                {
                    Posts.Add(post.Subreddit, new List<Post>());
                }
                Posts[post.Subreddit].Add(post);

                url.Add(post.Listing.Preview + " ");
            }

            int index = random.Next(url.Count);
            string urlString = url[index];
            var json = JObject.Parse(urlString);

            await ctx.RespondAsync(json["images"][0]["source"]["url"].ToString()).ConfigureAwait(false);
        }

        [Command("Dogs")]
        [Aliases("Dog")]
        [Description("Displays a picture of dog picked from r/dogpictures")]
        public async Task Dog(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var reddit = new RedditClient(appId: API_keys.redditAppID, appSecret: API_keys.redditAppSecret, refreshToken: API_keys.redditRefreshToken);
            var random = new Random();
            var url = new List<string> { "" };

            IDictionary<string, IList<Post>> Posts = new Dictionary<string, IList<Post>>();
            foreach (Post post in reddit.Subreddit("dogpictures").Posts.Top)
            {
                if (!Posts.ContainsKey(post.Subreddit))
                {
                    Posts.Add(post.Subreddit, new List<Post>());
                }
                Posts[post.Subreddit].Add(post);

                url.Add(post.Listing.Preview + " ");
            }

            int index = random.Next(url.Count);
            string urlString = url[index];
            var json = JObject.Parse(urlString);

            await ctx.RespondAsync(json["images"][0]["source"]["url"].ToString()).ConfigureAwait(false);
        }

        [Command("Dankmemes")]
        [Description("Post a meme from Reddit")]
        public async Task redditMeme(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var reddit = new RedditClient(appId: API_keys.redditAppID, appSecret: API_keys.redditAppSecret, refreshToken: API_keys.redditRefreshToken);
            var random = new Random();
            var url = new List<string> { "" };

            IDictionary<string, IList<Post>> Posts = new Dictionary<string, IList<Post>>();
            foreach (Post post in reddit.Subreddit("memes").Posts.Top)
            {
                if (!Posts.ContainsKey(post.Subreddit))
                {
                    Posts.Add(post.Subreddit, new List<Post>());
                }
                Posts[post.Subreddit].Add(post);

                url.Add(post.Listing.Preview + " ");
            }

            int index = random.Next(url.Count);
            string urlString = url[index];
            var json = JObject.Parse(urlString);
            Console.WriteLine(json);

            await ctx.RespondAsync(json["images"][0]["source"]["url"].ToString()).ConfigureAwait(false);
        }


    }
}
