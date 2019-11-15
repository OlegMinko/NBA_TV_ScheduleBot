namespace NBA_TV_ScheduleBot.ActionResults
{
    public class BaseResultData<T> : BaseResult
    {
        public BaseResultData(bool isSucceed, string errorMessage = null)
        {
            IsSucceed = isSucceed;
            ErrorMessage = errorMessage;
        }

        public BaseResultData(bool isSucceed, T data, string errorMessage = null)
        {
            IsSucceed = isSucceed;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public T Data { get; }
    }

}
