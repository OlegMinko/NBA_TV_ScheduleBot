using NBA_TV_ScheduleBot.Services.AggregatorServices;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace NBA_TV_ScheduleBot.Services.RestServices
{
    public class TelegramCommandHandler
    {
        private readonly ITelegramBotClient botClient;

        public TelegramCommandHandler(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
        }

        public async Task GetWeekSchedule(MessageEventArgs e)
        {
            Console.WriteLine($"TV Schedule. Received a text message in chat {e.Message.Chat.Id}.");

            int days = TelegramMessageParser.GetTvScheduleDays(e.Message);
            var schedule = new ScheduleAgregaror().GetSchedule(days);
            var message = new TelegramMessagesBuilder().GetTvSchedule(schedule);

            await botClient.SendTextMessageAsync(e.Message.Chat, message, ParseMode.Markdown);
        }
    }
}
