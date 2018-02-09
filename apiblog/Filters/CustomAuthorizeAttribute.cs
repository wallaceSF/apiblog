using System;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web.Http;

using apiblog.Services;
using apiblog.Controllers;
using System.Security.Claims;
using System.Net;

using apiblog.Models;
using System.Collections.Generic;

namespace apiblog.Filters
{   
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public object[] Roles;

        public CustomAuthorizeAttribute(params object[] roles)
        {
            Roles = roles;
        }

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
            var c = actionContext.ActionDescriptor.GetParameters();
            var k = c;

            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        private void AuthorizeRequest(string Token)
        {            
            var Secret = ConfigurationManager.AppSettings.Get("secret");

            var Jwt = new JwtServices();
            Jwt.validateToken(Secret, Token);

            var SecurityToken = Jwt.ReadToken(Token);
            
            var RoleToken = SecurityToken.Claims.FirstOrDefault(c => c.Type == "role").Value;

            int RoleLevel = 0;
            var AllRoles = new List<int>(); ;
            foreach (RolesUser role in Enum.GetValues(typeof(RolesUser)))
            {           
                if (RoleToken == role.ToString())
                {
                    RoleLevel = (int)role;
                }

                AllRoles.Add((int)role);
            }

            if (!AllRoles.Contains(RoleLevel))
            {
                throw new Exception("Não tem mais permissão");
            }           
        }

    }
}