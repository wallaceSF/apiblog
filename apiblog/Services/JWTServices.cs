﻿using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace apiblog.Services
{
    public class JWTServices
    {
        Dictionary<string, object> _PayLoad;
        string _Secret = ConfigurationManager.AppSettings.Get("secret");

        public JWTServices(DateTime PrazoFinal, Dictionary<string, object> PayLoad)
        {            
            var secondsSinceEpoch = (PrazoFinal - new DateTime(1970, 1, 1)).TotalSeconds;

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