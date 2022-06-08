using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;
using System.Linq;

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
                await ctx.Channel.TriggerTypingAsync();

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

        [Command("Server")]
        [Description("Displays information about this server")]
        public async Task Guildinfo(CommandContext ctx)
        {
            await ctx.Channel.TriggerTypingAsync();

            var embed = new DiscordEmbedBuilder
            {
                Title = ctx.Guild.Name,
                Color = ctx.Member.Color,

                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = ctx.Guild.IconUrl
                }
            };

            embed.AddField("ServerID", ctx.Guild.Id.ToString());
            embed.AddField("Owner", ctx.Guild.Owner.Username);
            embed.AddField("Total members", ctx.Guild.MemberCount.ToString());
            embed.AddField("Serverboost", ctx.Guild.PremiumTier.ToString());
            embed.AddField("Creation date", ctx.Guild.CreationTimestamp.UtcDateTime.ToShortDateString());

            await ctx.Channel.SendMessageAsync(embed);
            return;
        }

        [Command("User")]
        [Description("Displays a users information")]
        public async Task User(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.TriggerTypingAsync();

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
            embed.AddField("test", member.Presence.Activity.Name);
            embed.AddField("Hypesquad", member.Flags.ToString());
            embed.AddField("Is a Bot?", member.IsBot.ToString());
            embed.AddField("Created", member.CreationTimestamp.DateTime.ToLongDateString());
            embed.AddField("Joined this server at", member.Guild.JoinedAt.DateTime.ToLongDateString());
            embed.AddField("Bitches", "0");

            await ctx.Channel.SendMessageAsync(embed);
            return;
        }

        [Command("Avatar")]
        [Description("Displays a users avatar")]
        public async Task Avatar(CommandContext ctx, DiscordMember member)
        {
            await ctx.Channel.TriggerTypingAsync();

            await ctx.Channel.SendMessageAsync(member.AvatarUrl).ConfigureAwait(false);
            return;
        }

        [Command("Changenick")]
        [Description("Changes the nickname of a member (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Admin", "Owner")]
        public async Task Addchnl(CommandContext ctx, DiscordMember member, string message)
        {
            if (message.Contains(message))
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync($"Changed {member.Username}s nickname to {message}").ConfigureAwait(false);
                await member.ModifyAsync(x => x.Nickname = message).ConfigureAwait(false);
                return;
            }
            else
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync("please provide a valid member").ConfigureAwait(false);
                return;
            }
        }

        [Command("Createchnl")]
        [Description("Adds a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Admin", "Owner")]
        public async Task Addchnl(CommandContext ctx, string message)
        {
            if (message.Contains(message))
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync($"Created channel: {message}").ConfigureAwait(false);
                await ctx.Guild.CreateChannelAsync(message, DSharpPlus.ChannelType.Text).ConfigureAwait(false);
                return;
            }
            else
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync("please provide a name for the channel").ConfigureAwait(false);
                return;
            }
        }

        [Command("Delchnl")]
        [Description("Deletes a channel (must be a moderator or higher)")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
        public async Task Delchnl(CommandContext ctx, string message)
        {
            if (message.Contains(message))
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync($"Deleted channel: {message}").ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.TriggerTypingAsync();

                await ctx.Channel.SendMessageAsync("you did not provide a valid channel name").ConfigureAwait(false);
                return;
            }
        }

    }
}
