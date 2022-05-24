using Discord;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace DootBot2.Commands
{
    class Management : BaseCommandModule
    {
        [Hidden]
        [Command("setact")]
        private async Task setactivity(CommandContext ctx)
        {
            if (ctx.User.Id == 461446979155918859)
            {
                DiscordActivity activity = new DiscordActivity();
                DiscordClient discord = ctx.Client;
                string input = "Doot";
                activity.Name = input;
                await discord.UpdateStatusAsync(activity);
                return;
            }
            else
            {
                return;
            }
        }

        [Command("User")]
        [Description("Displays a users information")]
        public async Task User(CommandContext ctx, DiscordMember member)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = member.DisplayName,
                Url = "https://www.youtube.com/watch?v=xvFZjo5PgG0",
                Description = "i am dumbass lol",

                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = member.AvatarUrl
                }
            };

            embed.AddField("UserID", member.Id.ToString());
            embed.AddField("Status:", member.Presence.Status.ToString());

            if (member.Presence.Activity.ActivityType.Equals(DSharpPlus.Entities.ActivityType.Playing))
            {
                embed.AddField("Activity", "not currently doing anything");
            }
            else
            {
                embed.AddField("Playing: ", member.Presence.Activity.Name.ToLower());
            }

            embed.AddField("Created:", member.CreationTimestamp.DateTime.ToLongDateString());
            embed.AddField("Joined at:", member.Guild.JoinedAt.DateTime.ToLongDateString());

            await ctx.Channel.SendMessageAsync(embed: embed);
            return;
        }

        [Command("addchnl")]
        [Description("Adds a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        public async Task addchnl(CommandContext ctx, string message)
        {
            if (message.Contains(message))
            {
                await ctx.Channel.SendMessageAsync($"added channel: {message}").ConfigureAwait(false);
                await ctx.Guild.CreateChannelAsync(message, DSharpPlus.ChannelType.Text).ConfigureAwait(false);
                return;
            }
            else
            {
                await ctx.Channel.SendMessageAsync("please provide a name for the channel").ConfigureAwait(false);
                return;
            }
        }

        //[Command("delchnl")]
        //[Description("Deletes a channel (must be a moderator or higher)")]
        //[RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        //public async Task delchnl(CommandContext ctx, string message)
        //{
        //    if (message.Contains(message))
        //    {
        //        await ctx.Channel.SendMessageAsync($"deleted channel: {message}").ConfigureAwait(false);
        //        await ctx.Guild.(message).ConfigureAwait(false);
        //    }
        //    else
        //    {
        //        await ctx.Channel.SendMessageAsync("you did not provide a valid channel name").ConfigureAwait(false);
        //        return;
        //    }
        //}

    }
}
