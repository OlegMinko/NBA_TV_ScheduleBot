using NBA_TV_ScheduleBot.ActionResults;
using NBA_TV_ScheduleBot.Dto;
using System;
using System.Collections.Generic;

namespace NBA_TV_ScheduleBot
{
    public interface IOllTvRestService
    {
        BaseResultData<List<ScheduleDto>> GetScheduleByСhannel(string channel, DateTime date, string filter = "NBA", string ignore = "Обзор");
    }
}
