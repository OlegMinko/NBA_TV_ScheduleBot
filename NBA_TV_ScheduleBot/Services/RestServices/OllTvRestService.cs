using System;
using System.Collections.Generic;
using System.Linq;
using NBA_TV_ScheduleBot.ActionResults;
using NBA_TV_ScheduleBot.Dto;
using NBA_TV_ScheduleBot.Responses;
using RestSharp;

namespace NBA_TV_ScheduleBot
{
    public class OllTvRestService : IOllTvRestService
    {
        private readonly RestClient client;

        public OllTvRestService()
        {
            client = new RestClient();
        }

        public BaseResultData<List<ScheduleDto>> GetScheduleByСhannel(string channel, DateTime date, string filter = "NBA", string ignore = "Обзор")
        {
            var request = new RestRequest($"https://oll.tv/api/tv/epg?id={channel}&date={date.ToString("yyyy-MM-dd")}", Method.GET);

            var response = client.Execute<OllTvScheduleResponse>(request);
            if (!response.IsSuccessful)
            {
                return new BaseResultData<List<ScheduleDto>>(false);
            }

            if (response.Data == null || response.Data.data ==null)
            {
                return new BaseResultData<List<ScheduleDto>>(false);
            }

            var events = response.Data.data.Where(x => x.name.Contains(filter) && !x.name.Contains(ignore));
            var mappedEvents = MapEvents(events);

            return new BaseResultData<List<ScheduleDto>>(true, mappedEvents);
        }

        private static List<ScheduleDto> MapEvents(IEnumerable<OllTvScheduleItem> nbaEvents)
        {
            var result = new List<ScheduleDto>();
            foreach (var item in nbaEvents)
            {
                result.Add(new ScheduleDto
                {
                    EventName = item.name.Replace("Баскетбол. NBA. ", ""),
                    ScheduleTime = DateTime.Parse(item.start)
                });
            }

            return result;
        }
    }
}
