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
    class UserCommands : BaseCommandModule
    {
        //this command will display information about a user
        [Command("User")]
        [Description("Displays a users information")]
        public async Task User(CommandContext ctx, DiscordMember member)
        {
            //will let people know the bot is working
            await ctx.Channel.TriggerTypingAsync();

            //gets the roles of the specified user
            var roles = member.Roles;

            //creates a new embed which will have the information
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

            //creates a new field which displays the id
            embed.AddField("UserID", member.Id.ToString());

            //checks if the user is offline (doesnt work)
            if (member.Presence.Status == UserStatus.Offline)
            {
                Console.WriteLine("it works");
            }
            //check if the user is online then adds it to the embed
            else if (member.Presence.Status == UserStatus.Online)
            {
                embed.AddField("Status", "Online");
            }
            //check if the user is idle then adds it to the embed
            else if (member.Presence.Status == UserStatus.Idle)
            {
                embed.AddField("Status", "Idle");
            }
            //check if the user is in do not disturb then adds it to the embed
            else if (member.Presence.Status == UserStatus.DoNotDisturb)
            {
                embed.AddField("Status", "Do Not Disturb");
            }
            //check if the user is invisible then adds it to the embed
            else if (member.Presence.Status == UserStatus.Invisible)
            {
                embed.AddField("Status", "Invisible");
            }


            string test = string.Empty;

            if (roles.Count() == 0)
            {
                embed.AddField("Roles", "No roles");
            }
            else
            {
                foreach (var userRole in roles)
                {
                    test += userRole.Mention + " ";
                }

                embed.AddField("Roles", test);
            }

            //gets the hypesquad the user is a part of
            embed.AddField("Hypesquad", member.Flags.ToString().Replace("House", ""));

            //checks if the mentioned user is a bot
            embed.AddField("Is a Bot?", member.IsBot.ToString());

            //gets< the creation date of the user
            embed.AddField("Created", member.CreationTimestamp.DateTime.ToLongDateString());

            //gets the date in which the user joined the current server
            embed.AddField("Joined this server at", member.Guild.JoinedAt.DateTime.ToLongDateString());

            //trolled
            embed.AddField("Bitches", "0");

            //sends the embed to the channel which the command was executed
            await ctx.Channel.SendMessageAsync(embed);
            return;
        }

        [Command("Avatar")]
        [Description("Displays a users avatar")]
        public async Task Avatar(CommandContext ctx, DiscordMember member)
        {
            //lets the user know that the bot is working
            await ctx.Channel.TriggerTypingAsync();

            //sends an embed with the users avatar
            await ctx.Channel.SendMessageAsync(member.AvatarUrl).ConfigureAwait(false);
            return;
        }
    }
}
