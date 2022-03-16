using System;

namespace Core.Results
{
    public class Result : IResult
    {
        //public Result(bool success, string message, Exception ex) : this(success, message)
        //{
        //    Exception = ex;
        //}

        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
        //public Exception Exception { get; }
    }
}
