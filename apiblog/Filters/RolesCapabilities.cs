using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using apiblog.Services;

namespace apiblog.Filters
{
    public class RolesCapabilities : ActionFilterAttribute
    {
   
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var method = actionContext.Request.Method.Method;
            var arguments = actionContext.ActionArguments.Count();
            var controllerName = actionContext.ControllerContext.ControllerDescriptor.ControllerName;

            var checkRole = new CheckRoleCapabilities(method, arguments, controllerName);                        
        }
    }
}