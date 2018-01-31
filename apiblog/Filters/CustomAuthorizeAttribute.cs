using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;

using apiblog.Services;

namespace apiblog.Filters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {        
            if (SkipAuthorization(actionContext)) {
                return;
            }
      
            var Authorization = actionContext.Request.Headers.Authorization;
        
            if(Authorization == null) {
                throw new Exception("Não foi passado Header Authorization");
            }

            var token = Authorization.Parameter;            

            if (token == null) {
                throw new Exception("erro token inválido");
            }

            AuthorizeRequest(token);
        }

        private static bool SkipAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            Contract.Assert(actionContext != null);

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        private void AuthorizeRequest(string Token)
        {            
            var Secret = ConfigurationManager.AppSettings.Get("secret");

            var Jwt = new JwtServices();
            Jwt.validateToken(Secret, Token);        
        }

    }
}