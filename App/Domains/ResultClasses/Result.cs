namespace Domains.ResultClasses
{
    [Serializable]
    public class Result
    {
        public Result()
        {
            
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess;
        public string Message;
    }
}
