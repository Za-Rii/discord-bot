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
   public class PublicModule : ModuleBase
    {
    
		[Command("meow")]
        [Summary("Replies for testing")]
        public async Task ping()
        {   
            Color color_ = new Color(255, 50, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"*Nyaaa~*   **{(Context.Client as DiscordSocketClient).Latency}ms**");
                var textfield = new EmbedFieldBuilder()
                .WithName($":ping_pong: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
        }
        		
        [Command("boot")]
        [Summary("Throws a boot at a user")]
        public async Task boot(IGuildUser mentionedUser)
        {
            Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"Threw a :boot: at {mentionedUser.Mention}!");
                var textfield = new EmbedFieldBuilder()
                .WithName($"{Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
        }

                [Command("opensesame")]
        [Summary("Displays a list of my commands and their uses.")]
        public async Task opensesame()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=oTRZOYTev4g");
        }
            
        [Command("bottle")]
        [Summary("Bottle a user")]
        public async Task bottle(IGuildUser mentionedUser)
        {
            Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"Smashed a :beer: over {mentionedUser.Mention}'s head!");
                var textfield = new EmbedFieldBuilder()
                .WithName($"{Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
        }
        [Command("htlhcdtwy")]
        [Summary("LHC")]
        public async Task LHC()
        {
            await ReplyAsync($"Has the large hadron collider destroyed the world yet?       " + $"{Format.Bold("NO")}");
        }
                
        		[Command("animeimage")]
                [Alias("animu")]
                [Summary("posts an anime pic")]
                public async Task animeimage()
                {
                 var rand = new Random();
                 var animeimagecall = new string[]
                 {
                     "modules/animeimages/car.jpeg",
                     "modules/animeimages/couch.jpg",
                     "modules/animeimages/evil.gif",
                     "modules/animeimages/giphy.gif",
                     "modules/animeimages/happy.gif",
                     "modules/animeimages/cute.jpg",
                     "modules/animeimages/yuno.jpg",
                     "modules/animeimages/rwby.jpg",
                     "modules/animeimages/large.gif",
                     "modules/animeimages/bluuu.jpg",
                     "modules/animeimages/scared.gif",
                     "modules/animeimages/erza.gif",
                     "modules/animeimages/beaten.gif",
                     "modules/animeimages/circle.gif"
                     
                 };

                 int animeimgindex = rand.Next(animeimagecall.Length);
                 string animeimgtopost = animeimagecall[animeimgindex];
                 await Context.Channel.SendFileAsync(animeimgtopost);
                }
        		[Command("finger")]
                [Summary("puts the finger")]
                public async Task finger()
                {
                 await Context.Channel.SendFileAsync("modules/animeimages/finger.gif");
                }

                [Command("randomnumber")]
                [Alias("roll")]
                [Summary("random number")]
                public async Task randomnumber()
                {
                 var rand = new Random();
                 var numbercall = new string[]
                 {
                     "one",
                     "two",
                     "three",
                     "four",
                     "five",
                     "six",
                 };

                 int numberindex = rand.Next(numbercall.Length);
                 string numbertopost = numbercall[numberindex];
                 Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"**Rolled a *:{numbertopost}:!***");
                var textfield = new EmbedFieldBuilder()
                .WithName($"{Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
                }

                [Command("coinflip")]
                [Alias("coin")]
                [Summary("coin")]
                public async Task coinflip()
                {
                 var rand = new Random();
                 var flip = new string[]
                 {
                     "Tails",
                     "Heads",
                 };

                 int flipresult = rand.Next(flip.Length);
                 string numbertopost = flip[flipresult];
                 Color color_ = new Color(0, 160, 255);
            SocketGuild sockGuild = Context.Guild as SocketGuild;  
            var message_ = ($"**Flipped a coin and it landed on: *{numbertopost}***");
                var textfield = new EmbedFieldBuilder()
                .WithName($":moneybag: {Context.Message.Author.Username}")
                .WithValue(message_);
                var embed_ = new EmbedBuilder()
            .WithColor(color_)
           .AddField(textfield);
           
        await Context.Channel.SendMessageAsync("",false,embed_);
                 
                }

                		[Command("squeaksqueak")]
                        [Summary("tells kaylen to shut up")]
                        public async Task squeaksqueak()
                        {
                         await Context.Channel.SendMessageAsync("**KAYLEN SHUT THE FUCK UP**");
                        }

                [Command("qotd")]
                [Summary("qotd")]
                        public async Task Say()
                        {
                         await Context.Channel.SendMessageAsync($"This is the Quote of the Day \n $*{DateTime.UtcNow}*");
                        }
                [Command("echo")]
                [Alias("say")]
                [Summary("lol")]
                [RequireUserPermissionAttribute(GuildPermission.Administrator)]
                public async Task Say([Remainder, Summary("The text to echo")] string echo)
                    {
                //ReplyAsync is a mtheod on modulebase
                        await ReplyAsync(echo);
                        await Context.Message.DeleteAsync();
                    }
                	[Command("google"), Summary("Will google for you")]
                    public async Task Google([Summary("Subject to google"), Remainder]string google)
                        {
                            string search = google.Replace(" ", "%20");
                            await Context.Channel.SendMessageAsync("<https://lmgtfy.com/?q=" + search + ">");
                        }
                                
                    [Group("r6strat")]
                    public class Sample : ModuleBase
                    {
                		[Command("attack")]
                        [Summary("r6")]
                        public async Task attack()
                        {
                         var rand = new Random();
                         var numbercall = new string[]
                         {
                         "**ATTACK** -- **Shield Team SIX!!** - All Players, play an operator with a Shield, if there are no more then choose Recruit with a shield.",
                         "**ATTACK** -- **Turtle Squad** - All Players, play an operator with a Shield and crawl *only* after you enter the building."
                          };
                         int numberindex = rand.Next(numbercall.Length);
                         string numbertopost = numbercall[numberindex];
                         await Context.Channel.SendMessageAsync($"{numbertopost}");
                        }

                        [Command("defend")]
                        [Summary("r6")]
                        public async Task defend()
                        {
                         var rand = new Random();
                         var numbercall = new string[]
                         {
                         "**DEFEND** -- **3's a Crowd, More is Insane** - Everyone stays in the Objective room, do not leave the room for any reason.",
                         "**DEFEND** -- **Never Eat Soggy Weetbix** - All players must spread out on each side of the building according to the compass, with one player in the objective."
                          };
                         int numberindex = rand.Next(numbercall.Length);
                         string numbertopost = numbercall[numberindex];
                         await Context.Channel.SendMessageAsync($"{numbertopost}");
                        }
                        		
                        [Command("8ball")]
                        [Alias("ball")]
                         public async Task eightball(string query)
                            {
                                string[] responses = {"Nooo!", "Yes!", "Certainly!", "Nope.","Try again.", "What?","Negatory.", "Computer says No.", "Tomorrow for Sure.", "Nah." };
                            await Context.Channel.SendMessageAsync($"{Context.User.Mention}: {query}\n{responses[new Random().Next(0, responses.Length)]}");
                            }
                                
                    };
                    

        private static string GetUptime()
            => (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString(@"dd\.hh\:mm");
        private static string GetHeapSize() => Math.Round(GC.GetTotalMemory(true) / (1024.0 * 1024.0), 2).ToString();
    }
    
}
   

 