using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace apiblog.Services
{
    public class JWTServices
    {
        Dictionary<string, object> _PayLoad;
        string _Secret = ConfigurationManager.AppSettings.Get("secret");

        public JWTServices(DateTime PrazoInicial, DateTime PrazoFinal, Dictionary<string, object> PayLoad)
        {
            // var secondsSinceEpoch = Math.Round((PrazoFinal - PrazoInicial).TotalSeconds);

            var post2038 = new DateTime(2018, 1, 19, 3, 14, 8, DateTimeKind.Utc);
            var secondsSinceEpoch = (post2038 - new DateTime(1970, 1, 1)).TotalSeconds;

            PayLoad.Add("exp", secondsSinceEpoch);

            _PayLoad = PayLoad;
        }

        public JWTServices(Dictionary<string, object> PayLoad)
        {
            _PayLoad = PayLoad;
        }

        public string GenerateToken()
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
           
            return encoder.Encode(_PayLoad, _Secret);
        }
    }
}