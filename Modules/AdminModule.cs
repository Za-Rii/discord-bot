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
   public class NameModule : ModuleBase
    {
    	[Command("ban")]
        [Summary("Bans a User")]
        [RequireUserPermissionAttribute(GuildPermission.BanMembers)]
        public async Task ban(IGuildUser mentionedUser)
        {
            var server = (Context.Guild);
            await server.AddBanAsync(mentionedUser);
            await Context.Channel.SendMessageAsync($"The **BAN HAMMER** has struck {mentionedUser.Username} (ID:{mentionedUser.Id})!! They may no longer return to **{Context.Guild.Name}**...");
        }


        [Command("unban")]
        [Summary("unans info")]
        [RequireUserPermissionAttribute(GuildPermission.Administrator)]
        public async Task unban()
        {
            await Context.Channel.SendMessageAsync($"**You cannot unban someone using me!** \nIf you wish to unban someone, please do it through your Discord Server's Settings.");
        }

        		[Command("kick")]
                [Summary("kicks mentioned user")]
                [RequireUserPermissionAttribute(GuildPermission.KickMembers)]
                public async Task kick(IGuildUser mentionedUser)
                {
                var server = (Context.Guild);
                 await (mentionedUser.KickAsync());
                 await Context.Channel.SendMessageAsync($"**{mentionedUser}** has just been kicked from **{server.Name}** by {Context.User.Username}. *They can join back with another invite!*");
                }

        		[Command("purge")]
                [Summary("deletes messages")]
                [RequireUserPermissionAttribute(GuildPermission.ManageMessages)]
                    public async Task Purge([OptionalAttribute] string x)
        {
            int xmd = 10;
            IChannel deletefrom = Context.Channel;
                    int xm;

                    if (x != null)
                    {
                        if ((Int32.TryParse(x, out xm)))
                        {
                            xmd = xm;
                        }
                        else
                        {
                            await ReplyAsync("Invalid Value. Please enter a number.");
                        }
                    }
                    if(xmd <= 100 && xmd >= 0)
                    {
                        if(xmd == 100)
                        {
                            var messagesToDelete = await Context.Channel.GetMessagesAsync(xmd, CacheMode.AllowDownload).Flatten();
                            await Context.Channel.DeleteMessagesAsync(messagesToDelete);
                        }else
                        {
                            var messagesToDelete = await Context.Channel.GetMessagesAsync(xmd + 1, CacheMode.AllowDownload).Flatten();
                            await Context.Channel.DeleteMessagesAsync(messagesToDelete);
                        }
                        IMessage confirmMessage = await Context.Channel.SendMessageAsync("**I have deleted** " + xmd.ToString() + " **messages for you, **" + $"{Context.User.Mention}" +"!");
                        await Task.Delay(5000);
                        await confirmMessage.DeleteAsync();
                    }
                    else
                    {
                        if(xmd > 100)
                        {
                            IMessage confirmMessage = await Context.Channel.SendMessageAsync("**Sorry,**" + Context.User.Mention + "**, I can't delete more than 100 messages!**");
                                                        await Task.Delay(5000);
                            await confirmMessage.DeleteAsync();
                        }else
                        {
                            IMessage invalidMessage = await Context.Channel.SendMessageAsync("That is an invalid integer. Please enter a valid number!");
                            await Task.Delay(5000);
                            await invalidMessage.DeleteAsync();
                        }
                    }
                }

                		[Command("mute")]
                        [Alias("shutup")]
                        [Summary("mutes a user")]
                        [RequireUserPermissionAttribute(GuildPermission.MuteMembers)]
                        public async Task mutes(IGuildUser mentionedUser)
                        {
                            var muted = (mentionedUser.IsMuted);
                         if (!muted)
                         {
                            muted=true;
                            await Context.Channel.SendMessageAsync($"**{mentionedUser}** has been muted by **{Context.User.Username}**");
                         }
                        else
                        {
                           IMessage msg = await Context.Channel.SendMessageAsync($"This user is already muted!");
                           await Task.Delay(5000);
                            await msg.DeleteAsync(); 
                        }
                        }
                        [Command("unmute")]
                        [Summary("unmutes a user")]
                        [RequireUserPermissionAttribute(GuildPermission.MuteMembers)]
                        public async Task unmutes(IGuildUser mentionedUser)
                        {
                            var muted = (mentionedUser.IsMuted);
                         if (muted)
                         {
                            muted=false;
                            await Context.Channel.SendMessageAsync($"**{mentionedUser}** has been unmuted by **{Context.User.Username}**");
                         }
                        else
                        {
                           IMessage msg = await Context.Channel.SendMessageAsync($"This user can already speak!!");
                           await Task.Delay(5000);
                            await msg.DeleteAsync(); 
                        }

            }
            		

            }      
    }
