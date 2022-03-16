using System;

namespace Core.Results
{
    public class ErrorResult : Result
    {
        //public ErrorResult(Exception exception, string message) : base(false, message, exception)
        //{

        //}
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
