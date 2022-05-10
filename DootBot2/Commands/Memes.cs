using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using vars;
namespace DootBot2.Commands
{
    class Memes : BaseCommandModule
    {
        memelist memz = new memelist();
        List<string> meamea = memz.getMemes();

        [Command("Memes")]
        [Description("Posts a random meme")]
        public async Task Meme(CommandContext ctx)
        {
            var random = new Random();
            int index = random.Next(meamea.Count);

            await ctx.RespondAsync(meamea[index]).ConfigureAwait(false);
            Console.WriteLine("Command worked");
        }

        [Command("memecount")]
        [Description("Displays the amount of memes saved to this bot")]
        public async Task MemeCount(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("There are " + meamea.Count + " memes saved").ConfigureAwait(false);
        }



    }

}


