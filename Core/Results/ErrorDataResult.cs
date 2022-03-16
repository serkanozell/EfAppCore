using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //public ErrorDataResult(T data, string message, Exception exception) : base(data, false, message, exception)
        //{

        //}
        public ErrorDataResult(T data, string messsage) : base(data, false, messsage)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
