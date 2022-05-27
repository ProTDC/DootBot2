using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
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
                Title = member.DisplayName + " #" + member.Discriminator,
                Url = "https://www.youtube.com/watch?v=xvFZjo5PgG0",
                Description = "Description here",
                Color = DiscordColor.Blue,

                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = member.AvatarUrl
                }
            };

            embed.AddField("UserID:", member.Id.ToString());
            embed.AddField("Status:", member.Presence.Status.ToString());
            embed.AddField("Has Permissions:", member.Permissions.ToPermissionString());
            embed.AddField("Test:", member.Guild.Roles.ToString());  //doesnt work
            embed.AddField("Is a Bot?", member.IsBot.ToString());
            embed.AddField("Created:", member.CreationTimestamp.DateTime.ToLongDateString());
            embed.AddField("Joined this server at:", member.Guild.JoinedAt.DateTime.ToLongDateString());

            await ctx.Channel.SendMessageAsync(embed);
            return;
        }
           

        [Command("addchnl")]
        [Description("Adds a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        public async Task Addchnl(CommandContext ctx, string message)
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
        //public async Task Delchnl(CommandContext ctx, string message)
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

        [Command("Silence")]
        [Description("Adds a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        public async Task Silence(CommandContext ctx, DiscordMember member)
        {
            var emoji = DiscordEmoji.FromName(ctx.Client, ":ok_hand:");
            var message = await ctx.RespondAsync($"{member.Mention}, react with {emoji}.");

            var result = await message.WaitForReactionAsync(member, emoji);

            if (!result.TimedOut)
            {
                await ctx.RespondAsync("Thank you!");
            }
        }

    }
}
