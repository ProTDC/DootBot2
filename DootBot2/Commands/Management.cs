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
        private async Task Setact(CommandContext ctx)
        {
            if (ctx.User.Id == 461446979155918859)
            {
                DiscordActivity activity = new DiscordActivity();
                DiscordClient discord = ctx.Client;
                string input = "Doot";
                activity.Name = input;
                await discord.UpdateStatusAsync(activity);
                await ctx.Channel.SendMessageAsync("https://media.discordapp.net/attachments/956994953727336448/980798142343675934/unknown.png").ConfigureAwait(false);
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
                Title = $"{member.Username}#{member.Discriminator}",
                Url = "https://www.youtube.com/watch?v=xvFZjo5PgG0",
                Description = $"aka: {member.Nickname}", 
                Color = member.Color,

                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = member.AvatarUrl
                }
            };

            embed.AddField("UserID", member.Id.ToString());
            embed.AddField("Status", member.Presence.Status.ToString()); //Doesn't work on offline people
            embed.AddField("Hypesquad", member.Flags.ToString());
            embed.AddField("Is a Bot?", member.IsBot.ToString());
            embed.AddField("Created", member.CreationTimestamp.DateTime.ToLongDateString());
            embed.AddField("Joined this server at", member.Guild.JoinedAt.DateTime.ToLongDateString());
            embed.AddField("Bitches", "0");

            await ctx.Channel.SendMessageAsync(embed);
            return;
        }

        [Command("Changenick")]
        [Description("Changes the nickname of a member (must be a moderator or higher)")]
        //[RequireRoles(RoleCheckMode.Any, "Moderator", "Admin", "Owner")]
        public async Task Addchnl(CommandContext ctx, DiscordMember member, string message)
        {
            if (message.Contains(message))
            {
                await ctx.Channel.SendMessageAsync($"Changed {member.Mention}s nickname to {message}").ConfigureAwait(false);
                await member.ModifyAsync(x => x.Nickname = message).ConfigureAwait(false);
                return;
            }
            else
            {
                await ctx.Channel.SendMessageAsync("please provide a valid member").ConfigureAwait(false);
                return;
            }
        }

        [Command("addchnl")]
        [Description("Adds a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Admin", "Owner")]
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

        //[Command("Silence")]
        //[Description("Adds a channel (must be a moderator or higher)")]
        //[RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        //public async Task Silence(CommandContext ctx, DiscordMember member)
        //{
        //    var emoji = DiscordEmoji.FromName(ctx.Client, ":ok_hand:");
        //    var message = await ctx.RespondAsync($"{member.Mention}, react with {emoji}.");

        //    var result = await message.WaitForReactionAsync(member, emoji);

        //    if (!result.TimedOut)
        //    {
        //        await ctx.RespondAsync("Thank you!");
        //    }
        //}

    }
}
