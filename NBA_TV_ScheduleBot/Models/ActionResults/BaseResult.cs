namespace NBA_TV_ScheduleBot.ActionResults
{

    public class BaseResult
    {
        public BaseResult()
        {

        }

        public BaseResult(bool isSucceed, string errorMessage = null)
        {
            IsSucceed = isSucceed;
            ErrorMessage = errorMessage;
        }

        public bool IsSucceed { get; set; }
        public string ErrorMessage { get; set; }
    }

}
