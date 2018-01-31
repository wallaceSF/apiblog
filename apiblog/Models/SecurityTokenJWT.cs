using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace apiblog.Models
{
    public class SecurityTokenJWT
    {
        public IEnumerable<Claim> Subject;
        public DateTime? NotBefore;
        public String SigningKey;
        public String Issuer;
        public DateTime? IssuedAt;
        public DateTime? Expires;
        public String Audience;
    }
}