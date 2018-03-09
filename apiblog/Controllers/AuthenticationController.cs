using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Security.Claims;

using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;
using apiblog.Services;
using System.Configuration;

namespace apiblog.Controllers
{
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {
        private const int DURACAO_TOKEN_HORAS = 1;

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

            UsuarioServices UsuarioServices = new UsuarioServices(new ContextData());

            Usuario Usuario = UsuarioServices.Get(AuthenticateModel.Username);
               
            var ListClaim = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, Usuario.Pessoa.Nome),
                new Claim(ClaimTypes.NameIdentifier, (Usuario.Pessoa.Emails.Count != 0 ? Usuario.Pessoa.Emails[0].Endereco : "emaildefault@teste.com")),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            var SecurityTokenJWT = new SecurityTokenJWT
            {
                Subject = ListClaim,
                NotBefore = DateTime.Now,
                SigningKey = ConfigurationManager.AppSettings.Get("secret"),
                Issuer = "self",
                IssuedAt = DateTime.Now,
                Expires = DateTime.Now.AddHours(DURACAO_TOKEN_HORAS),
            };
       
            var Jwt = new JwtServices(); 
            
            return Ok(new { success = true, token = Jwt.generateToken(SecurityTokenJWT) });
        }
  
    }
}
