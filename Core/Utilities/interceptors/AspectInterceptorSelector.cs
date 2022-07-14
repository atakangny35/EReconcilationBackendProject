using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.interceptors
{
    public class AspectInterceptorSelector: IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method,IInterceptor[] ınterceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethotIterceptionBaseAttribute>(true).ToList();
            var MethodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethotIterceptionBaseAttribute>(true).ToList();

            classAttributes.AddRange(MethodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
