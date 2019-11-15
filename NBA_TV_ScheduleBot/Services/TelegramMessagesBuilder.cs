using NBA_TV_ScheduleBot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBA_TV_ScheduleBot.Services
{
    public class TelegramMessagesBuilder
    {
        public string GetTvSchedule(Dictionary<DateTime, List<ScheduleDto>> schedule)
        {
            var message = new StringBuilder();
            foreach (var day in schedule)
            {
                //Day header
                message.AppendLine($"\U00002796 {day.Key.ToLongDateString()} \U00002796");

                foreach (var item in day.Value.OrderBy(x => x.ScheduleTime))
                {
                    message.AppendLine($"*{item.ScheduleTime.ToString("hh:mm tt")}* `{item.ChannelName}` \U000025AB {item.EventName}");
                }
                message.AppendLine();
            }

            return message.ToString();
        }
    }
}
