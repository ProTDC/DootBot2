using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;


namespace DootBot2.Commands
{
    class Memes : BaseCommandModule
    {
        MemeList memelist = new MemeList();


        [Command("Memes")]
        [Description("Posts a random meme")]
        public async Task Meme(CommandContext ctx)
        {
            var random = new Random();
            int index = random.Next(memelist.meamea.Count);

            await ctx.RespondAsync(memelist.meamea[index]).ConfigureAwait(false);
            return;
        }

        [Command("Memecount")]
        [Description("Displays the amount of memes saved to this bot")]
        public async Task MemeCount(CommandContext ctx) 
        {
            await ctx.Channel.SendMessageAsync($"There are {memelist.meamea.Count} memes saved").ConfigureAwait(false);
            return;
        }

    }

}


