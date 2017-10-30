using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Entities
{
    public class Email
    {
        public int IdEmail { get; set; }
        public string Endereco { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}