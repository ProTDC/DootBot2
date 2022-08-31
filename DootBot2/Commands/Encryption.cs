using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using NETCore.Encrypt;

namespace DootBot2.Commands
{
    class Encryption : BaseCommandModule
    {
        //[Command("Key")]
        //[Description("Creates a new key")]
        //public async Task Key(CommandContext ctx)
        //{

        //}

        [Command("Encrypt")]
        [Description("Encrypts a message")]
        public async Task Encrypt(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            var combinedMessage = "";
            foreach(string word in message)
            {
                combinedMessage += word;
            }

            var encrypted = EncryptProvider.Base64Encrypt(combinedMessage);
            await ctx.RespondAsync(encrypted.ToString());

            await ctx.Message.DeleteAsync();
        }

        [Command("Decrypt")]
        [Description("Decrypts a message")]
        public async Task Decrypt(CommandContext ctx, params string[] message)
        {
            await ctx.TriggerTypingAsync();

            var combinedMessage = "";
            foreach (string word in message)
            {
                combinedMessage += word;
            }

            var decrypted = EncryptProvider.Base64Decrypt(combinedMessage);

            await ctx.RespondAsync(decrypted.ToString());
        }
    }
}
