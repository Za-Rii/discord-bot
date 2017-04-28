using System.Threading.Tasks;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using System;
using Discord.Audio;
using System.Linq;
using Discord;
using System.Runtime.InteropServices;
using System.Diagnostics;
namespace discordbot
{
    public class CommandHandler
    {
        private CommandService commands;
        private DiscordSocketClient client;
        private IDependencyMap map;
     //   private musicservice musicService;

        public async Task Install(IDependencyMap _map)
        {
            // Create Command Service, inject it into Dependency Map
            client = _map.Get<DiscordSocketClient>();
            commands = new CommandService();
         //   map.Add(musicService);
            _map.Add(commands);
            map = _map;

            await commands.AddModulesAsync(Assembly.GetEntryAssembly());

            client.MessageReceived += HandleCommand;
            
        }

        public async Task HandleCommand(SocketMessage parameterMessage)
        {
            var message = parameterMessage as SocketUserMessage;

            if (message == null) return;

            int argPos = 0;

            if (!(message.HasMentionPrefix(client.CurrentUser, ref argPos) || message.HasCharPrefix('^', ref argPos))) return;
            
            var context = new CommandContext(client, message);

            var result = await commands.ExecuteAsync(context, argPos, map);

            var application = await context.Client.GetApplicationInfoAsync();
            
            if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
            {
            Color color_ = new Color(255, 0, 0);
            SocketGuild sockGuild = context.Guild as SocketGuild;  
            var message_ = ($"**{result.ErrorReason}**");
            var footer_ = new EmbedFooterBuilder()
            
            .WithText("Please refer to the help command.");
                var textfield = new EmbedFieldBuilder()
                .WithName($":x: {context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
           
        await context.Channel.SendMessageAsync("",false,embed_);
            }

        }
    }

    }

