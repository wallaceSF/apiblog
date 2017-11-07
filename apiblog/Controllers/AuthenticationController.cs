using apiblog.Models;
using apiblog.Services;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
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

            var AuthenticationService = new AuthenticationService(AuthenticateModel);

            if (!AuthenticationService.Authenticate())
            {
               
                return Ok(new
                    {
                        success = false,
                        message = "senha errada"
                    }
                );
            }
                    
            var DataAtual = DateTime.Now;            
            var DataModificada = DataAtual.AddHours(3);

            var secondsSinceEpoch = Math.Round((DataModificada - DataAtual).TotalSeconds);

            var payload = new Dictionary<string, object>
                {
                    { "claim1", 0 },
                    { "claim2", "claim2-value"},
                    { "exp", secondsSinceEpoch }
                };

            var secret = ConfigurationManager.AppSettings.Get("secret");            

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            var token = encoder.Encode(payload, secret);            

            return Ok(new { success = true, token = token });
        }
    }
}
