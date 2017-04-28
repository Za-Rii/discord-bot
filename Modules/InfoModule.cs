using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace discordbot.Modules
{
   public class InfoModule : ModuleBase
   {
       		[Command("game")]
        [Summary("Shows what game the user is playing")]
        public async Task game(IGuildUser mentionedUser)

        
        {

            
            if (mentionedUser.Game!=null)
            {
            
            Color color = new Color(0, 255, 50);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message = ($"**Is Currently Playing: `{mentionedUser.Game}`!**");
                var textfield = new EmbedFieldBuilder()
                .WithName($"🎮 {mentionedUser.Username}")
                .WithValue(message);
                var embed = new EmbedBuilder()
            .WithColor(color)
            .WithThumbnailUrl(mentionedUser.GetAvatarUrl())
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed);
        }
                else
                {
                    
            Color color = new Color(255, 255, 0);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message = ($"**This user is not playing a game right now!**");
                var textfield = new EmbedFieldBuilder()
                .WithName($":x: {mentionedUser.Username}")
                .WithValue(message);
                var embed = new EmbedBuilder()
            .WithColor(color)
            .WithThumbnailUrl(mentionedUser.GetAvatarUrl())
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed);
                }
        }

        [Command("userinfo")]
        [Summary("Shows information about a user.")]
        public async Task userinfo(IGuildUser mentionedUser)
        { 

Color color = new Color(0, 160, 255);
            string title = $"Showing some Info for {mentionedUser.Username}!";
            var message = (
            $"{Format.Bold("Username:")} {mentionedUser.Username}\n\n" +
            $"{Format.Bold("Nickname:")} {mentionedUser.Nickname}\n\n" +
            $"{Format.Bold("Joined At:")} {mentionedUser.JoinedAt} \n\n" +
            $"{Format.Bold("User Discriminator:")} {mentionedUser.Discriminator} \n\n" +
            $"{Format.Bold("Is A Bot?:")} {mentionedUser.IsBot} \n\n" +
            $"{Format.Bold("Client ID:")} {mentionedUser.Id} \n\n ");
            var embedfield = new EmbedFieldBuilder()
                .WithValue(message)
                .WithName("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            var author = new EmbedAuthorBuilder()
                .WithName($"Hey, {Context.User.Username}!");
            var footer = new EmbedFooterBuilder()
            .WithText($"**For more help, join my Discord Server:** https://discord.gg/rzHKVMn");
            
            var embed = new EmbedBuilder()
                .WithColor(color)
                .WithTitle(title)
                .AddField(embedfield)
                .WithThumbnailUrl(mentionedUser.GetAvatarUrl())
                .WithFooter(footer)
                .Build();

            await Context.Channel.SendMessageAsync("", false, embed);
            
             //Gets the Mentioned User's AvatarURL
        }

        [Command("help")]
        [Summary("Displays a list of my commands and their uses.")]
        public async Task help()
        {
            // Embed Box
                       Color color = new Color(0, 160, 255);
            string title = "Here's a list of my Commands~!";

            var message = (
            $"- {Format.Bold("Help")} Shows this list. \n" +
            $"- {Format.Bold("Boot")} Throws a boot at a specified user **<Mention a User>**\n" +
            $"- {Format.Bold("Meow")} Do it and find out. \n" +
            $"- {Format.Bold("OpenSesame")} Well, I've done all I can do... \n" +
            $"- {Format.Bold("Bottle:")} Smashes a bottle over a user's head **<Mention a User>**\n" + 
            $"- {Format.Bold("Animeimage or Animu")} Posts a random anime image from a selection. \n" + 
            $"- {Format.Bold("Coinflip")} Flips a coin.\n" +
            $"- {Format.Bold("Roll")} Rolls a Six Sided dice. \n" + 
            $"- {Format.Bold("R6Strat")} Provides a silly strat for Rainbow 6 Siege - \nParameters <Attack> <Defend>\n" +
            $"- {Format.Bold("Echo:")} Repeats what you said.");
            var infomessage = (
                $"- {Format.Bold("About:")} Shows info about the bot **<Mention a User>**\n" +
                $"- {Format.Bold("UserInfo")} Shows information of a user **<Mention a User>**\n" +
                $"- {Format.Bold("ServerInfo:")} Shows information about this server \n" +
                $"- {Format.Bold("Invite:")} An Invite link so I can join your server! \n" +
                $"- {Format.Bold("Game")} Shows the Game the mentioned user is playing. **<Mention a User>** \n" +
                $"- {Format.Bold("Avatar")} Gets the Avatar of the mentioned user **<Mention a User>**");
          
            var startfield = new EmbedFieldBuilder()
                .WithValue($"{Format.Italics("My Prefix is: **^**")} **<Used like this: ^meow>**")
                .WithName("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                
            var embedfield = new EmbedFieldBuilder()
                .WithValue(message)
                .WithName("Basic Commands (No Perms Needed)");

            var pagefield = new EmbedFieldBuilder()
                .WithName("Use '^help 2' in the server for my second lot of commands!\n (I do not take PM messages)")
                .WithValue(":arrow_right: ");

            var infofield = new EmbedFieldBuilder()
                .WithValue(infomessage)
                .WithName("Information Commands");

            var author = new EmbedAuthorBuilder()
                .WithName($"Hey, {Context.User.Username}!");

            
            //var botimage = ("https://cdn.discordapp.com/avatars/290359206207291392/79e31bb1fab2b3413a7a74c191c11645.png?size=128");
            
            var embed = new EmbedBuilder()
                .WithColor(color)
                .WithAuthor(author)
                .WithTitle(title)
                .AddField(startfield)
                .AddField(embedfield)
                .AddField(infofield)
                .AddField(pagefield)
                .WithThumbnailUrl("https://images.discordapp.net/avatars/290359206207291392/81541f3bd86dd7b8dfa708c6cf86bfcc.jpg?size=1024")
                .WithCurrentTimestamp()
                .Build();


            await (await Context.User.CreateDMChannelAsync()).SendMessageAsync("",false,embed);

            Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ("**Hey! Go check your PMs!** *(The help you asked for is in there)*");
                var textfield = new EmbedFieldBuilder()
                .WithName($":bookmark: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
        }
        		[Command("help 2")]
                [Summary("Second Help Page")]
                public async Task help2()
                {
                             Color color = new Color(0, 160, 255);
            string title = "Second Page of Commands~!";

            var footer = new EmbedFooterBuilder()
            .WithText($"{Format.Bold("For more help, join my Discord Server: https://discord.gg/rzHKVMn")}");
            var helpmessage = ("**Contact ProxiiZ** \n *Discord:* - ProxiiZ#6144 \n *Steam:* http://steamcommunity.com/id/ProxiiZ/ \n *Discord Server:* https://discord.gg/rzHKVMn");
            var helpfield = new EmbedFieldBuilder()
                .WithValue(helpmessage)
                .WithName("Additional Help:");
            var message = (
                $"- {Format.Bold("Ban")} Bans the mentioned user. **<Requires a User to be Mentioned>**\n" +
                $"- {Format.Bold("Kick")} Kicks the mentioned user. **<Requires a User to be Mentioned>**\n" +
                $"- {Format.Bold("Purge")} Deletes X amount of messages from the channel. **<Optional Number, default is 10>** \n*(Thanks to Justice for $purge)*");
            var embedfield = new EmbedFieldBuilder()
                .WithValue(message)
                .WithName("Administration Commands:");

            var startfield = new EmbedFieldBuilder()
                .WithValue($"{Format.Italics("My Prefix is: **^**")}  **<Used like this: ^meow>**")
                .WithName("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            var author = new EmbedAuthorBuilder()
                .WithName($"Hey, {Context.User.Username}!");
            
            var botimage = ("https://images.discordapp.net/avatars/290359206207291392/81541f3bd86dd7b8dfa708c6cf86bfcc.jpg?size=1024");

            var embed = new EmbedBuilder()
                .WithColor(color)
                .WithTitle(title)
                .WithAuthor(author)
                .AddField(startfield)
                .AddField(embedfield)
                .WithFooter(footer)
                .WithThumbnailUrl(botimage)
                .Build();


            await (await Context.User.CreateDMChannelAsync()).SendMessageAsync("",false,embed);

            Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ("**Hey! Go check your PMs!** *(The help you asked for is in there)*");
                var textfield = new EmbedFieldBuilder()
                .WithName($":bookmark: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
                }
                [Command("About")]
        [Summary("Bot Info")]  
                public async Task Info()
        {
var application = await Context.Client.GetApplicationInfoAsync();
        // Embed Box
                        Color color = new Color(0, 160, 255);
            string title = "**Information About Airi**\n";

            var message = (
                $"{application.Owner} (ID {application.Owner.Id})" );
            var botVersion = ($"Airi - v0.5" );
            var dateCreated = ($"Sunday 12th March 2017");
            var Library = ($"Discord.Net: ({DiscordConfig.Version})");
            var runtime = ($"{RuntimeInformation.FrameworkDescription} {RuntimeInformation.OSArchitecture}");
            var lastUpdate = ($"({GetUptime()})");
            var guildCount = ($"({(Context.Client as DiscordSocketClient).Guilds.Count})");
            var authorServer = ("https://discord.gg/rzHKVMn");
            var footer = new EmbedFooterBuilder()
            .WithText($"**For more help, join my Discord Server:** https://discord.gg/rzHKVMn");
            
                var embedfield = new EmbedFieldBuilder()
                    .WithValue(message)
                    .WithName("Author:");

                var versionfield = new EmbedFieldBuilder()
                    .WithValue(botVersion)
                    .WithName("Bot Version:");

                var datefield = new EmbedFieldBuilder()
                    .WithValue(dateCreated)
                    .WithName("Created:");
            
                var libraryfield = new EmbedFieldBuilder()
                    .WithValue(Library)
                    .WithName("Library:");

                var runtimefield = new EmbedFieldBuilder()
                    .WithValue(runtime)
                    .WithName("Runtime:");

                var updatefield = new EmbedFieldBuilder()
                    .WithValue(lastUpdate)
                    .WithName("Time Since last Downtime or Update:");

                var guildfield = new EmbedFieldBuilder()
                    .WithValue(guildCount)
                    .WithName("Guilds:");
                
                var authorfield = new EmbedFieldBuilder()
                    .WithValue(authorServer)
                    .WithName("Author's Server:");

            var author = new EmbedAuthorBuilder()
                .WithName(Context.User.Username);

            var botimage = (application.IconUrl);

            var embed = new EmbedBuilder()
                .WithColor(color)
                .WithTitle(title)
                .AddField(embedfield)
                .AddField(versionfield)
                .AddField(datefield)
                .AddField(libraryfield)
                .AddField(runtimefield)
                .AddField(updatefield)
                .AddField(guildfield)
                .AddField(authorfield)
                .WithFooter(footer)
                .WithThumbnailUrl(botimage)
                .Build();


            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("invite")]
        [Summary("Returns the OAuth2 Invite URL of the bot")]
        public async Task Invite()
        {
            var application = await Context.Client.GetApplicationInfoAsync();

            Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"A user with the 'Manage Server' permissions can invite me to your server here: \n<https://discordapp.com/oauth2/authorize?client_id={application.Id}&scope=bot>");
                var textfield = new EmbedFieldBuilder()
                .WithName($":e_mail: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
           
        }
        [Command("serverinfo")]
        [Summary("Shows Server's info")]
        public async Task serverinfo()
        {
                        // Embed Box
                       Color color = new Color(0, 160, 255);
            string title = $"Showing Info for *{Context.Guild.Name}*!";
            SocketGuild sockGuild = Context.Guild as SocketGuild;
            var members = (sockGuild.Users.Count());
            var showOwner = (sockGuild.Owner.Username);
            var message = ($"- **Name:** {Context.Guild.Name}\n- **Owner:** {showOwner} \n- **Server ID:** {sockGuild.Id} \n") + ($"- **Created:** {sockGuild.CreatedAt} \n- **Voice Region:** {sockGuild.VoiceRegionId} \n"+ $"- **Members:** {members}");
            var embedfield = new EmbedFieldBuilder()
                .WithValue(message)
                .WithName("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
var application = await Context.Client.GetApplicationInfoAsync();
            var author = new EmbedAuthorBuilder()
                .WithName($"Hey, {Context.User.Username}!");
                var footer = new EmbedFooterBuilder()
            .WithText($"**For more help, join my Discord Server:** https://discord.gg/rzHKVMn");

            
            var embed = new EmbedBuilder()
                .WithColor(color)
                .WithTitle(title)
                .AddField(embedfield)
                .WithFooter(footer)
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .Build();

                await Context.Channel.SendMessageAsync("", false, embed);
        }
        		[Command("avatar")]
               [Alias("profilepic")]
                [Summary("avaatr")]
                public async Task avatar(IGuildUser mentionedUser)
                {
                 Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"{mentionedUser.GetAvatarUrl()}");
                var textfield = new EmbedFieldBuilder()
                .WithName($"{mentionedUser.Username}'s Avatar")
                .WithValue(mentionedUser.GetAvatarUrl());
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield)
           .WithImageUrl(mentionedUser.GetAvatarUrl());
        await Context.Channel.SendMessageAsync("",false,embed_);
                }
                private static string GetUptime()
            => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();
   }
}