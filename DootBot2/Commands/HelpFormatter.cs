﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Text;

namespace DootBot2.Commands
{
    class CustomHelpFormatter : DefaultHelpFormatter
    {
        public CustomHelpFormatter(CommandContext ctx) : base(ctx) { }

        public override CommandHelpMessage Build()
        {
            EmbedBuilder.Description = "test";
            EmbedBuilder.Color = DiscordColor.Blue;
            EmbedBuilder.Url = "https://www.youtube.com/watch?v=WTWyosdkx44";
            EmbedBuilder.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTXSXaT2sNW2XGDEnvz5vEkJ5vD27XYpxb_Y9l96gmFxUH7ZbgwFhQsMm6_jlgr4kFifuo&usqp=CAU";

 

            return base.Build();
        }

    }
}
