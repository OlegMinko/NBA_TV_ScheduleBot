using System.Linq;
using Telegram.Bot.Types;

namespace NBA_TV_ScheduleBot.Services
{
    public static class TelegramMessageParser
    {
        public static int GetTvScheduleDays(Message message)
        {
            var days = 1;
            var messageSplited = message.Text.Split(' ');
            if (messageSplited.Count() == 2)
            {
                if (int.TryParse(messageSplited[1], out int parsedDays))
                {
                    days = parsedDays;
                }
            }

            return days;
        }
    }
}
