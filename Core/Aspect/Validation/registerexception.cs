using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Validation
{
    public class registerexception: System.Exception
    {
        public registerexception()
         : base()
        { }

        public registerexception(String message)
            : base(message)

        { }

        public registerexception(String message, Exception innerException)
            : base(message, innerException)
        { }

        protected registerexception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
