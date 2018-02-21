using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using nicobot.Core.UserAccounts;
using NReco.ImageGenerator;
using Newtonsoft.Json;
using System.Net;

namespace nicobot.Modules
{
    public class Misc : ModuleBase<SocketCommandContext>
    {

        [Command("WhatLevelIs")]
        public async Task WhatLevelIs(uint xp)
        {
            uint level = (uint)Math.Sqrt(xp / 50);
            await Context.Channel.SendMessageAsync("The level is " + level);
        }

        [Command("react")]
        public async Task HandleReactionMessage()
        {
            RestUserMessage msg = await Context.Channel.SendMessageAsync("react to me");
            Global.MessageIdToTrack = msg.Id;
        }

        [Command("stats")]
        public async Task Stats([Remainder]string arg = "")
        {
            SocketUser target = null;
            var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
            target = mentionedUser ?? Context.User;

            var account = UserAccounts.GetAccount(target);
            await Context.Channel.SendMessageAsync($"{target.Mention} has {account.XP} exp and {account.Points} points.");
        }

        [Command("hello")]
        public async Task Hello([Remainder] string arg = "")
        {
            var mentionedUser = Context.Message.MentionedUsers.FirstOrDefault();
            string css = "<style>\n    body{\n        background-image: url(https://cdn.discordapp.com/attachments/393526436343971851/415031891268206593/Nero-text.jpg);\n    }\n    h1{\n        color: rgb(180, 0, 0)\n    }\n</style>\n";
            string html = String.Format("<font size=20><h1>Welcome to Aestus, {0}</h1></font>", mentionedUser.Username);
            var converter = new HtmlToImageConverter
            {           
                Width = 2056,
                Height = 1156
            };
            var pngBytes = converter.GenerateImage(css + html, NReco.ImageGenerator.ImageFormat.Jpeg);
            await Context.Channel.SendFileAsync(new MemoryStream(pngBytes), "слыш письку саси :))).jpg");
        }

        [Command("ban")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Ban()
        {

        }

        [Command("addXP")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task AddXP(uint xp)
        {
            var account = UserAccounts.GetAccount(Context.User);
            account.XP += xp;
            UserAccounts.SaveAccounts();
            await Context.Channel.SendMessageAsync($"You gained {xp} xp.");
        }

        [Command("help")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync("ну типа тут нихуя пока нет)0) \nбота заного делаю<:Xo4y_CDoXHyT_Blyat:403812608354025472>");
        }

        [Command("say")]
        public async Task Say([Remainder]string message)
        {
            var embed = new EmbedBuilder();
            embed.WithTitle("Пидор на " + Context.User.Username + " сказал");
            embed.WithDescription(message);
            embed.WithColor(new Color(0, 180, 0));
            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("choose")]
        public async Task Pickone([Remainder]string message)
        {
            string[] options = message.Split(new string[] { "или" }, StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("трунь");
            embed.WithDescription(selection);
            embed.WithColor(new Color(255, 255, 0));
            embed.WithThumbnailUrl("https://cdn.discordapp.com/emojis/403898766727577611.png?v=1");

            await Context.Channel.SendMessageAsync("", false, embed);
            DataStorage.AddPairToStorage(Context.User.Username + " " + DateTime.Today + DateTime.Now.ToLongTimeString(), selection);

        }

        [Command("welcome")]
        public async Task Welcome()
        {
            string user = Context.User.Username;
            string guild = "Aestus Domus Aurea";
            string botName = "Неро";
            string message = String.Format("Привет, **{0}**. Я бот гильдии **{1}**. Меня зовут 🌹**{2}**🌹. Могу ли я помочь тебе?", user, guild, botName);

            await Context.Channel.SendMessageAsync(message);
        }

        [Command("secret")]
        public async Task RevSecret([Remainder]string arg = "")
        {
            if (!UserIsSecretOwner((SocketGuildUser)Context.User))
            {
                var embed = new EmbedBuilder();
                embed.WithDescription("получи pepsi, " + Context.User.Mention);
                embed.WithColor(new Color(0xFFFFFF));

                await Context.Channel.SendMessageAsync("", false, embed);
                return;
            }
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
            await dmChannel.SendMessageAsync(Utilities.GetAlert("SECRET"));
        }

        private bool UserIsSecretOwner(SocketGuildUser user)
        {
            string targetRoleName = "bepis";
            var result = from r in user.Guild.Roles
                         where r.Name == targetRoleName
                         select r.Id;
            ulong roleID = result.FirstOrDefault();
            if (roleID == 0) return false;
            var targetRole = user.Guild.GetRole(roleID);
            return user.Roles.Contains(targetRole);
        }
        
        [Command("data")]
        public async Task GetData()
        {
            await Context.Channel.SendMessageAsync("Data Has " + DataStorage.GetPairsCount() + " pairs.");
            DataStorage.AddPairToStorage("Count" + DataStorage.GetPairsCount(), "TheCount" + DataStorage.GetPairsCount());
        }
    }
}
