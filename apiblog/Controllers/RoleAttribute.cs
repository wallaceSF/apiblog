using System;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace apiblog.Controllers
{
    internal class RoleAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var a = "aaaa";
        }
    }
}