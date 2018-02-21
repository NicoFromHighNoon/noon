using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Discord;
using Discord.WebSocket;

namespace nicobot.Core
{
    internal static class RepeatingTimer
    {
        private static Timer loopingTimer;
        private static SocketTextChannel channel;

        internal static Task StartTimer()
        {
            channel = Global.Client.GetGuild(388428205763198986).GetTextChannel(411979495583514635);

            loopingTimer = new Timer()
            {
                Interval = 600000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTicked;

            return Task.CompletedTask;
        }

        private static async void OnTimerTicked(object sender, ElapsedEventArgs e)
        {
            string Umu1 = "https://cdn.discordapp.com/attachments/406605927945601034/415383154845810690/Umuanatomytriggermentionlistbewbdudestriggermentionlistthiccthighstriggermentionlistassmenifyoure_5a.jpg";
            string Umu2 = "https://cdn.discordapp.com/attachments/406605927945601034/415382561989197825/dwM2GOrtjyBf4BLvNQuTqdxcDo1V8D-EalojKruk3W8.jpg";
            string Umu3 = "https://cdn.discordapp.com/attachments/406605927945601034/415382280526233600/DPsqa8uW4AATNRA.jpg";
            string Umu4 = "https://cdn.discordapp.com/attachments/406605927945601034/415382275480616960/DKa3nuSXUAE4hdJ.jpg";
            string Umu5 = "https://cdn.discordapp.com/attachments/406605927945601034/415382272917766154/Dailydoseofumutriggermentionlistsmolholtriggermentionlistlewds4dheartsmolholhas_f5c8cc_6387606.jpg";
            string Umu6 = "https://cdn.discordapp.com/attachments/406605927945601034/415382267440136214/Blazedumutriggermentionlistsmolholtriggermentionlistlewds4dheart_d627bf_6405778.jpg";
            string Umu7 = "https://cdn.discordapp.com/attachments/406605927945601034/415382264344608768/Blank_cd8105494089d8c4b480fc6d30fc505d.jpg";
            string Umu8 = "https://cdn.discordapp.com/attachments/406605927945601034/415382260263550977/aPjWewG_460s.jpg";
            string Umu9 = "https://cdn.discordapp.com/attachments/406605927945601034/415382256522100736/396567947541217280.gif";
            string Umu10 = "https://cdn.discordapp.com/attachments/406605927945601034/415382253728694273/18157204_10155647518255348_4256301199928973229_n.png";
            string Umu11 = "https://cdn.discordapp.com/attachments/406605927945601034/415382245017124864/13732258_233031913764106_919167750_n.jpg";
            string Umu12 = "https://cdn.discordapp.com/attachments/406605927945601034/415382244748951563/Umutriggermentionlistlewds4dhearttriggermentionlistsmolholyouhadonejobfj_383a9b_6400735.jpg";
            string Umu13 = "https://cdn.discordapp.com/attachments/406605927945601034/415382177472053248/Umu_0ec32b17784865a4d31a53eb60092a60.jpg";
            string Umu14 = "https://cdn.discordapp.com/attachments/406605927945601034/415382175358124035/tumblr_p3r0ky04Jf1vssigio3_500.jpg";
            string Umu15 = "https://cdn.discordapp.com/attachments/406605927945601034/415382169448349711/tumblr_owzo761kCk1vwgwh5o1_500.jpg";
            string Umu16 = "https://cdn.discordapp.com/attachments/406605927945601034/415382168047583233/tumblr_ovze19kh6E1uemqfco1_1280.png";
            string Umu17 = "https://cdn.discordapp.com/attachments/406605927945601034/415382166894149632/tumblr_ool74z8Pwf1ssg673o2_500.png";
            string Umu18 = "https://cdn.discordapp.com/attachments/406605927945601034/415382162989383681/tumblr_om45qqTbnz1rf6fvpo1_500.jpg";
            string Umu19 = "https://cdn.discordapp.com/attachments/406605927945601034/415382162087608320/qr8jbc1y8gsy.jpg";
            string Umu20 = "https://cdn.discordapp.com/attachments/406605927945601034/415382161399480321/tenor.gif";
            string Umu21 = "https://cdn.discordapp.com/attachments/406605927945601034/415382160996827153/suZ2i60.png";
            string Umu22 = "https://cdn.discordapp.com/attachments/406605927945601034/415382158434238464/mods_faceplates_nero.jpg";

            string images = $"{Umu1} или {Umu2} или {Umu3} или {Umu4} или {Umu5} или {Umu6} или {Umu7} или {Umu8} или {Umu9} или {Umu10} или {Umu11} или {Umu12} или {Umu13} или {Umu14} или {Umu15} или {Umu16} или {Umu17} или {Umu18} или {Umu19} или {Umu20} или {Umu21} или {Umu22}";
            string[] options = images.Split(new string[] { "или" }, StringSplitOptions.RemoveEmptyEntries);

            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];

            var embed = new EmbedBuilder();
            embed.WithTitle("Новая порция Уму!");
            embed.WithImageUrl(selection);
            embed.WithColor(new Color(240, 160, 30));

            await channel.SendMessageAsync("", false, embed);
        }
    }
}
