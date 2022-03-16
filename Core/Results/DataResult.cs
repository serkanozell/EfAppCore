using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //public DataResult(T data, bool success, string message, Exception exception) : base(success, message, exception)
        //{

        //}
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
        //public Exception exception { get; }
    }
}
