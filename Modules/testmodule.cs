using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace discordbot.Modules
{
   public class testmodule : ModuleBase
    {
        		[Command("test")]
               [Alias("die")]
                [Summary("dep")]
                public async Task test()
                {
                    var author = Context.Message.Author;
                    var application = await Context.Client.GetApplicationInfoAsync();
                    if (author.Id != application.Owner.Id )
                        {
                            Color color_ = new Color(255, 0, 0);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ("**You're not my Owner!! -_-**");
                var textfield = new EmbedFieldBuilder()
                .WithName($":japanese_goblin: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
                        }
                    else
                    {
                        Color color_ = new Color(0, 255, 50);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"**H-Hey *{application.Owner.Username}***");
                var textfield = new EmbedFieldBuilder()
                .WithName($":heart: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           await Context.Channel.SendMessageAsync("",false,embed_);
                        
                    }
                }
                [Command("globalannounce"), Summary("Makes a global announcement to all connected guilds!")]
        [Alias("ga", "announce")]
        
        public async Task shout([Remainder, Summary("The message to annonce!")] string arg)
        {
            if (Context.User.Id != 136766598148128768)
                return;
            IEnumerable<IGuild> guilds = await Context.Client.GetGuildsAsync();
            foreach (IGuild guild in guilds)
            {
                IEnumerable<ITextChannel> channels = await guild.GetTextChannelsAsync();
                ITextChannel announcements = null;
                foreach (ITextChannel channel in channels)
                {
                    if (channel.Name == "announcements")
                    {
                        announcements = channel;
                        break;
                    }
                }
                if (announcements != null)
                    await announcements.SendMessageAsync($"**Announcement from ProxiiZ, Bot Dev:** \n`{arg}`");
            }
        }
                
    }
}