using apiblog.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

            if (!(AuthenticateModel.Username == "teste" && AuthenticateModel.Password == "teste"))
            {
                return Ok(new{
                    success = false,
                    message = "senha errada"}
                );
            }

            var payload = new Dictionary<string, object>
                {
                    { "claim1", 0 },
                    { "claim2", "claim2-value" }
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
