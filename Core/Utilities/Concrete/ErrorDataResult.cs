using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data) : base(Data, false)
        {
        }

        public ErrorDataResult(T Data,string Message) : base(Data, false, Message)
        {
        }
        public ErrorDataResult() : base(default,false)
        {
        }
        public ErrorDataResult(string message) : base(default, false,message)
        {
        }
    }
}
