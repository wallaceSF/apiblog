using System;
using System.Collections.Generic;

namespace apiblog.Entities
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime NascimentoData { get; set; }
        public virtual List<Email> Emails { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }        
    }
}