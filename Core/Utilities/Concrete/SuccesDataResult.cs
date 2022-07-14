using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Concrete
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult(T Data) : base(Data, true)
        {
        }

        public SuccesDataResult(T Data, string Message) : base(Data, true, Message)
        {
        }
        public SuccesDataResult():base(default,true)
        {

        }
    }
}
