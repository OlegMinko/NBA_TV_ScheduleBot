namespace NBA_TV_ScheduleBot.Responses
{

    public class OllTvScheduleItem
    {
        public int id { get; set; }
        public int id_item { get; set; }
        public int programm_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public int start_ts { get; set; }
        public string stop { get; set; }
        public int stop_ts { get; set; }
        public int under_parental_protect { get; set; }
        public bool parentalControl { get; set; }
        public int blackout { get; set; }
        public int dvr { get; set; }
        public int FK_catalog { get; set; }
    }

}
