using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Services
{
    public class Aniversariante : ILembrete
    {
        private Pessoa _Pessoa;
    
        public void SetPessoa(Pessoa Pessoa)
        {
            _Pessoa = Pessoa;
        }

        public string GetLembrete()
        {
            ///fazer codigo aqui depois
            //_Pessoa.NascimentoData;
            return "seu aniversário";
        }
    }
}