using System;

namespace NBA_TV_ScheduleBot.Dto
{
    public class ScheduleDto
    {
        public string ChannelName { get; set; }

        public string EventName { get; set; }

        public DateTime ScheduleTime { get; set; }
    }
}
