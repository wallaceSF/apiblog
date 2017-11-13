using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;
using apiblog.Services;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace apiblog.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        [AllowAnonymous]      
        public IHttpActionResult Authenticate(Authenticate AuthenticateModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthenticationService AuthenticationService = new AuthenticationService(AuthenticateModel);

            if (!AuthenticationService.Authenticate())
            {                
                return Unauthorized(new AuthenticationHeaderValue("Basic", "login ou senha invalidas"));             
            }

            DateTime DataAtual = DateTime.Now;
            DateTime DataModificada = DataAtual.AddHours(3);

            UsuarioServices UsuarioServices = new UsuarioServices(new ContextData());

            Usuario Usuario = UsuarioServices.Get(AuthenticateModel.Username);

            Dictionary<string, object> PayLoad = new Dictionary<string, object>
                {                    
                    { "id", Usuario.Pessoa.IdPessoa},
                    { "name", Usuario.Pessoa.Nome },                    
                };

            JWTServices JWTServices = new JWTServices(DataAtual, DataModificada, PayLoad);

            return Ok(new { success = true, token = JWTServices.GenerateToken() });

        }
  
    }
}
