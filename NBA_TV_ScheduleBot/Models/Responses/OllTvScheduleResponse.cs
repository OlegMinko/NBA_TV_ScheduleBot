using System.Collections.Generic;

namespace NBA_TV_ScheduleBot.Responses
{
    public class OllTvScheduleResponse
    {
        public int status { get; set; }
        public object message { get; set; }
        public List<object> errors { get; set; }
        public List<OllTvScheduleItem> data { get; set; }
        public int exitStatus { get; set; }
    }
}


 