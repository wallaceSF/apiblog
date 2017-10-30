using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Entities
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public virtual List<Email> Emails { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }
      //  public virtual List<Post> Posts { get; set; }
      //  public virtual List<Comentario> Comentarios { get; set; }
    }
}