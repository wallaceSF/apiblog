using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using apiblog.Models;

namespace apiblog.Services
{
    public class JwtServices
    {
        public String generateToken(SecurityTokenJWT securityTokenJWT)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityTokenJWT.SigningKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var Subject = new ClaimsIdentity(securityTokenJWT.Subject, "Custom");

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = Subject,
                NotBefore = securityTokenJWT.NotBefore,
                SigningCredentials = signingCredentials,
                Issuer = securityTokenJWT.Issuer,
                IssuedAt = securityTokenJWT.IssuedAt,
                Expires = securityTokenJWT.Expires,
                Audience = securityTokenJWT.Audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);

            return signedAndEncodedToken;
        }

        public IEnumerable<ClaimsIdentity> validateToken(string Secret, string Token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidAudience = null,
                ValidateIssuer = true,
                ValidIssuer = "self",
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {                
                SecurityToken mytoken = new JwtSecurityToken();
                var myTokenHandler = new JwtSecurityTokenHandler();
                var myPrincipal = myTokenHandler.ValidateToken(Token, validationParameters, out mytoken);
                return myPrincipal.Identities;
            }
            catch (SecurityTokenException SecurityTokenException)
            {
                throw new Exception(SecurityTokenException.Message.ToString());              
            }
            catch (Exception Exception)
            {
                System.Diagnostics.Debug.WriteLine("Authentication failed");
                throw new Exception(Exception.Message.ToString());       
            }
        }     
    }
}