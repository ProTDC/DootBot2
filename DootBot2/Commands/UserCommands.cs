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
                Title = $"{member.Username} #{member.Discriminator}",
                Url = "https://www.youtube.com/watch?v=xvFZjo5PgG0",
                Color = member.Color,

                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail
                {
                    Url = member.AvatarUrl
                }
            };

            //gets the current activity of the user
            var activity = member.Presence.Activities;

            //sets the users currently activity and displays it
            string actString = string.Empty;
            string actType = string.Empty;
            //string actCustom = string.Empty;

            foreach (DiscordActivity act in activity)
            {
                actString += act.Name;
                actType += act.ActivityType;
                //actCustom += act.CustomStatus.Name;
            }

            bool check = string.IsNullOrEmpty(actString);
            //bool check2 = string.IsNullOrEmpty(actCustom);

            if (check == true)
            {
                embed.AddField("Activity", "No activity");
            }
            else
            {
                embed.AddField(actType.Replace("Custom", "Currently "), actString.Replace("Custom Status", "'") + "'");
            }
            Console.WriteLine(check.ToString());

            //if(check2 == true)
            //{

            //}
            //else
            //{

            //}
            //embed.WithDescription(actCustom);

            //gets the users roles for the current server and displays them
            string role = string.Empty;
            if (roles.Count() == 0)
            {
                embed.AddField("Roles", "No roles");
            }
            else
            {
                foreach (var userRole in roles)
                {
                    role += userRole.Mention + " ";
                }

                embed.AddField("Roles", role);
            }

            //gets the hypesquad the user is a part of
            embed.AddField("Hypesquad", member.Flags.ToString().Replace("House", ""));

            //checks if the mentioned user is a bot
            embed.AddField("Is a Bot?", member.IsBot.ToString());

            //gets the creation date of the user
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

        [Command("Activity")]
        [Description("Displays a users activity")]
        public async Task Activity(CommandContext ctx, DiscordMember member)
        {
            string actString = string.Empty;
            string actType = string.Empty;
            var activity = member.Presence.Activities;

            foreach (var act in activity)
            {
                actString += act.Name;
                actType += act.ActivityType;
            }

            await ctx.RespondAsync($"{member.DisplayName} is currently {actType.ToString()} {actString}");
        }

        [Command("Roles")]
        [Description("Displays a users roles")]
        public async Task Roles(CommandContext ctx, DiscordMember member)
        {
            var roles = member.Roles;

            string role = string.Empty;
            if (roles.Count() == 0)
            {
                await ctx.RespondAsync("this user has no roles").ConfigureAwait(false);
            }
            else
            {
                foreach (var userRole in roles)
                {
                    role += userRole.Mention + ", ";
                }

                await ctx.RespondAsync($"This user has the roles: {role}").ConfigureAwait(false);
            }
        }

    }
}
