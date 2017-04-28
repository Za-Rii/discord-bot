using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Discord.Audio;
using System.Collections.Generic;

namespace discordbot
{
    public class Program
    {
        static void Main(string[] args) =>
            new Program().Run().GetAwaiter().GetResult();
        public DiscordSocketClient client;
        private CommandHandler handler;

        private bool testing = false;
        
        public async Task Run()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                
                //Set Log Type
              LogLevel = LogSeverity.Info,
              AudioMode = AudioMode.Outgoing
            });
                //Begin Logging
        client.Log += (message) => 
        { 
            Console.WriteLine($"{message.ToString()}");
            return Task.CompletedTask;
        };
        

        
                // Configure the client to use a Bot token, and use our token
        await client.LoginAsync(TokenType.Bot, "MjkwMzU5MjA2MjA3MjkxMzky.C6ZxmQ.2JGdq3Gm-rZst8U32qrurjHvwKY");
        client.SetGameAsync("^help | ^invite");
        // Connect the client to Discord's gateway
        await client.StartAsync();
        

        var map = new DependencyMap();
        map.Add(client);
        handler = new CommandHandler();
        await handler.Install(map);

        await client.WaitForGuildsAsync();


        client.UserJoined += async (user) =>
        {
                SocketRole roleZB = user.Guild.GetRole(272970042914766859);
                SocketTextChannel welcomeChannel = user.Guild.DefaultChannel as SocketTextChannel;
            Color color = new Color(0, 255, 50);
            string title = $":white_check_mark: User Joined!";
            SocketGuild sockGuild = user.Guild as SocketGuild;  
            var message = ($"{Format.Bold($"{user.Mention} just joined *{user.Guild.Name}!* \n *Enjoy your stay, {user.Mention}!*" )} ");
                var textfield = new EmbedFieldBuilder()
                .WithName(":white_check_mark: User Joined!")
                .WithValue(message);
                var embed = new EmbedBuilder()
            .WithColor(color)
            .WithThumbnailUrl(user.GetAvatarUrl())
           .AddField(textfield);
        await welcomeChannel.SendMessageAsync("",false,embed);
        /*IEnumerable<ITextChannel> channels = await user.Guild.GetTextChannel("");
                ITextChannel logs = null;
                foreach (ITextChannel channel in channels)
                {
                    if (channel.Name == "logs")
                    {
                        logs = channel;
                        break;
                    }
                }
                 var message_ = ($"{Format.Bold($"{user.Mention} just joined *{user.Guild.Name}!* \n *Enjoy your stay, {user.Mention}!*" )} ");
                var textfield_ = new EmbedFieldBuilder()
                .WithName(":white_check_mark: User Joined!")
                .WithValue(message_);
                if (logs != null){
                var embed_ = new EmbedBuilder()
            .WithColor(color)
            .WithThumbnailUrl(user.GetAvatarUrl())
           .AddField(textfield_);
        await welcomeChannel.SendMessageAsync("",false,embed);
              */  
        if (user.Guild.Id == 272967309612679180)
            {
                await user.AddRolesAsync(roleZB);
            }
        else
        {
            return;
        }
        };

        client.UserLeft += async (user) =>
        {
            
            Color color = new Color(255, 0, 0);
            string title = $":x: User Left!";
            SocketGuild sockGuild = user.Guild as SocketGuild;
            
           
            var message = ($"{Format.Bold($"{user.Mention} just left {user.Guild.Name}... See ya {user.Username}!")} ");
            var embedfield_ = new EmbedFieldBuilder()
                .WithValue(message)
                .WithName($":x: User Left!");
                var embed = new EmbedBuilder()
            .WithColor(color)
            .WithThumbnailUrl(user.GetAvatarUrl())
           .AddField(embedfield_);

             

            
            SocketTextChannel welcomeChannel = user.Guild.DefaultChannel as SocketTextChannel;
            await welcomeChannel.SendMessageAsync("", false, embed);
        };

        client.JoinedGuild += async (user) =>
        {
            
            var application = await client.GetApplicationInfoAsync();
            ITextChannel joinmessage = user.DefaultChannel;
            await joinmessage.SendMessageAsync($"Hey Guys, I'm `Airi.`\nI'm a Discord Bot created by {application.Name} for your entertainment/use. \n `Please remember to add a channel called 'announcements' to receive important notices from the bot dev!` \n`*Also, my Prefix is ^*`");
        };
        
        client.RoleCreated += async (user) =>
        
        {
            
            SocketTextChannel welcomeChannel = user.Guild.DefaultChannel as SocketTextChannel;
        
            IMessage msg = await welcomeChannel.SendMessageAsync($"**Hey, incase you didn't know; A new role has been added to your server with the name *{user.Name}*.**");
            await Task.Delay(5000);
            await msg.DeleteAsync(); 
        };
        
        

        //client.RoleDeleted += async (user) =>
        //{
            //IGuild logchannel = user.Guild.GetTextChannel("Log");

           // SocketTextChannel joinmessage = user.Guild.DefaultChannel as SocketTextChannel;
            
           // Color color = new Color(255, 0, 0); 
            //string title = "Role Deleted!";
//var message = ("**Hey, Thanks for adding me to your server!** \n\nYou can find out more about me or ask questions in my home Discord! \n\n (Do $about or $help! **=D** )");
           // var embedfield = new EmbedFieldBuilder()
            //.WithValue(message);
            // var embed = new EmbedBuilder()
           // .WithColor(color)
           // .WithTitle(title)
          //  .AddField(embedfield)
          //  .Build();
        //    await joinmessage.SendMessageAsync("", false, embed);
     //   };

        // Block this task until the program is exited.
        await Task.Delay(-1);

        }
       /// public async void DisconnectAsync()
       /// {
          ///  await client.DisconnectAsync();
           /// await client.LogoutAsync();
        ///}
    }
}
