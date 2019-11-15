using NBA_TV_ScheduleBot.Dto;
using System;
using System.Collections.Generic;

namespace NBA_TV_ScheduleBot.Services.AggregatorServices
{
    public interface IScheduleAgregaror
    {
        Dictionary<DateTime, List<ScheduleDto>> GetSchedule(int nextDays = 1);
    }
}
