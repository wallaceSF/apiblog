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

        public List<string> GetLembrete()
        {

            var DataNascimento = _Pessoa.NascimentoData;

            var DataAtual = DateTime.Now;
            var DataAtualNascimento = new DateTime(DataAtual.Year, DataNascimento.Month, DataNascimento.Day);

            var diffDate = (DataAtual - DataAtualNascimento).TotalDays;

            string mensagem = null;
            if(diffDate <= 3)
            {
                string dayString = string.Format("{0}", diffDate);                
                string[] day = dayString.Split(',');

                mensagem = "falta " + day[0] + " para seu aniversário";
            }

            if(diffDate < 1)
            {
                mensagem = "Parabéns pelo seu aniversário!";
            }
   

            List<string> lembretes = new List<string>
            {
                mensagem
            };

            return lembretes;
        }
    }
}