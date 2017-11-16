using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;
using apiblog.Services;

namespace apiblog.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        private const int DURACAO_TOKEN_HORAS = 3;

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

            DateTime DataExpiracao = (DateTime.UtcNow).AddHours(DURACAO_TOKEN_HORAS);            

            UsuarioServices UsuarioServices = new UsuarioServices(new ContextData());

            Usuario Usuario = UsuarioServices.Get(AuthenticateModel.Username);

            Dictionary<string, object> PayLoad = new Dictionary<string, object>
                {                    
                    { "id", Usuario.Pessoa.IdPessoa},
                    { "name", Usuario.Pessoa.Nome },                    
                };

            JWTServices JWTServices = new JWTServices(DataExpiracao, PayLoad);

            return Ok(new { success = true, token = JWTServices.GenerateToken() });

        }
  
    }
}
