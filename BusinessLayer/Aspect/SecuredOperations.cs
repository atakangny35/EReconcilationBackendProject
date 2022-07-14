using Castle.DynamicProxy;
using Core.extensions;
using Core.Utilities.interceptors;
using Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Aspect
{
   public  class SecuredOperations:methodInterceptors
    {
        private string[] roles;
        private IHttpContextAccessor httpContextAccessor;

        public SecuredOperations(string _roles)
        {
            roles = _roles.Split(",");
            httpContextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void Before(IInvocation invocation)
        {
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Yetersiz yetki!!");
        }
    }
}
