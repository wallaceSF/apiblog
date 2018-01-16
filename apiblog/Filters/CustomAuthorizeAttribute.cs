using JWT;
using JWT.Serializers;
using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;

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

        private void AuthorizeRequest(string token)
        {            
            var secret = ConfigurationManager.AppSettings.Get("secret");            

            try
            {
                IJsonSerializer serializer   = new JsonNetSerializer();
                IDateTimeProvider provider   = new UtcDateTimeProvider();
                IJwtValidator validator      = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder          = new JwtDecoder(serializer, validator, urlEncoder);

               decoder.Decode(token, secret, verify: true);                

            }
            catch (TokenExpiredException e) { 
                throw new Exception(e.Message.ToString());               
            }
            catch (SignatureVerificationException r) {
                throw new Exception(r.Message.ToString());
            }
        }

    }
}