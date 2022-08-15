using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DootBot2.Commands
{
    class Management : BaseCommandModule
    {
        [Hidden]
        [Command("s")]
        private async Task Setact(CommandContext ctx)
        {
            if (ctx.User.Id == 461446979155918859)
            {
                await ctx.Channel.TriggerTypingAsync();

                DiscordActivity activity = new DiscordActivity();
                DiscordClient discord = ctx.Client;
                string input = $"Doot || {discord.Guilds.Count()} Guilds+";
                activity.Name = input;
                await discord.UpdateStatusAsync(activity);
                await ctx.RespondAsync("https://media.discordapp.net/attachments/956994953727336448/980798142343675934/unknown.png").ConfigureAwait(false);
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

            await ctx.RespondAsync(embed);
            return;
        }

        [Command("Serverpic")]
        [Description("Displays the current servers picture")]
        public async Task ServerPic(CommandContext ctx)
        {
            await ctx.RespondAsync(ctx.Guild.IconUrl);
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
