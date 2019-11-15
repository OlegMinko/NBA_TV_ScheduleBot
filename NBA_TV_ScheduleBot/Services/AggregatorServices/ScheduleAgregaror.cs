using NBA_TV_ScheduleBot.Configurations;
using NBA_TV_ScheduleBot.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NBA_TV_ScheduleBot.Services.AggregatorServices
{
    public class ScheduleAgregaror : IScheduleAgregaror
    {
        private readonly IOllTvRestService ollTvRestService;

        private readonly string setantaChannelId;
        private readonly string viasatChannelId;

        public ScheduleAgregaror()
        {
            ollTvRestService = new OllTvRestService();

            setantaChannelId = Configuration.GetSetantaChannelId();
            viasatChannelId = Configuration.GetViasatChannelId();

        }

        public Dictionary<DateTime, List<ScheduleDto>> GetSchedule(int nextDays = 1)
        {
            var schedule = new Dictionary<DateTime, List<ScheduleDto>>();

            var scheduleRange = GenerateDateRange(nextDays);
            foreach (var date in scheduleRange)
            {
                schedule.Add(date, new List<ScheduleDto>());

                var setantaResult = ollTvRestService.GetScheduleByСhannel(setantaChannelId, date);
                if (setantaResult.IsSucceed && setantaResult.Data.Any())
                {
                    setantaResult.Data.ForEach(x => x.ChannelName = "Setanta");
                    schedule[date].AddRange(setantaResult.Data);
                }

                var viasatResult = ollTvRestService.GetScheduleByСhannel(viasatChannelId, date);
                if (viasatResult.IsSucceed && viasatResult.Data.Any())
                {
                    viasatResult.Data.ForEach(x => x.ChannelName = "Viasat ");
                    schedule[date].AddRange(viasatResult.Data);
                }
            }

            return schedule;
        }


        private List<DateTime> GenerateDateRange(int count)
        {
            var result = new List<DateTime>()
            {
                DateTime.UtcNow
            };

            int step = 1;
            while (step <= count)
            {
                result.Add(DateTime.UtcNow.AddDays(step++));
            }

            return result;
        }
    }
}
