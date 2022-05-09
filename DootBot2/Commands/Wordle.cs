//using DSharpPlus.CommandsNext;
//using DSharpPlus.CommandsNext.Attributes;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using WordleWords;

//namespace DootBot2.Commands
//{
//    class Wordle : BaseCommandModule
//    {
//        Random numberGen = new Random();

//        //int random = 0;

//        [Command("wordle")]
//        [Description("Starts a game of wordle")]
//        public async Task wordle(CommandContext ctx, [Description("guess")] string guess) 
//        {
//            if (guess.Length != 5) 
//            {
//                await ctx.Channel.SendMessageAsync(ctx.Member.DisplayName + ", your guess was not 5 characters long").ConfigureAwait(false);
//                Console.WriteLine(Words.WordList.Length);

//                return;
//            }


//        }
//    }
//}
