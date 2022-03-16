using System;

namespace Core.Results
{
    public class SuccessResult : Result
    {
        //public SuccessResult(Exception exception, string message) : base(true, message, exception)
        //{

        //}
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
