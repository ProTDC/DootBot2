using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;


namespace DootBot2.Commands

{
    class FunCommands : BaseCommandModule
    {

        [Command("Porn")]
        [Description("Displays porn")]
        public async Task Porn(CommandContext ctx)
        {
            await ctx.RespondAsync("Degenerates like you, belong on a cross").ConfigureAwait(false);
            Console.WriteLine("Command worked");
        }

        [Command("Motivation")]
        [Description("Displays motivation to keep on going")]
        public async Task Motivation(CommandContext ctx)
        {
            Console.WriteLine("Command worked");

            Random rand = new Random();

            if (rand.Next(0, 1) == 0)
                await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/424874562082045962/811358442786390056/Motivational_Lizard.mp4").ConfigureAwait(false);
            else
                await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/967031855985590383/971717012978036796/kys.mov").ConfigureAwait(false);

        }

        [Command("Celebrate")]
        [Description("Celebration")]
        public async Task Celebration(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/634063767466147840/971711431902908496/trim.E9946223-78D6-454C-867F-627BBF29429B.mov").ConfigureAwait(false);
            Console.WriteLine("Command worked");
        }

        //[Command("Poll")]
        //public async Task Poll(CommandContext ctx, TimeSpan duration, params DiscordEmoji[] emojiOptions)
        //{
        //    var interactivity = ctx.Client.GetInteractivity();
        //    var options = emojiOptions.Select(x => x.ToString());

        //    var embed = new DiscordEmbedBuilder
        //    {
        //        Title = "Poll",
        //        Description = string.Join("", options)
        //    };

        //    var pollMessage = await ctx.Channel.SendMessageAsync(embed: embed).ConfigureAwait(false);

        //    foreach (DiscordEmoji option in emojiOptions)
        //    {
        //        await pollMessage.CreateReactionAsync(option).ConfigureAwait(false);
        //    }

        //    var result = await interactivity.CollectReactionsAsync(pollMessage, duration).ConfigureAwait(false);
        //    var distinctResult = result.Distinct();
        //    var results = distinctResult.Select(x => $"{x.Emoji}: {x.Total}");


        //    await ctx.Channel.SendMessageAsync(string.Join("\n", results)).ConfigureAwait(false);
        //}
    }

}

