using apiblog.Entities;
using System.Collections.Generic;

namespace apiblog.Services
{
    public class LembreteService
    {
        private Pessoa _pessoa;

        public LembreteService(Pessoa pessoa)
        {
            _pessoa = pessoa;
        }

        public List<List<string>> GetLembrete()
        {                              
            List<List<string>> lembrete = new List<List<string>>(); 
            
            foreach (ILembrete list in this.Lembretes())
            {
                list.SetPessoa(_pessoa);
                lembrete.Add(list.GetLembrete());
            }

            return lembrete;
        }

        private List<ILembrete> Lembretes()
        {
            List<ILembrete> listLembrete = new List<ILembrete>
            {
                new Aniversariante(),
                new PostingInDraft()
            };

            return listLembrete;
        }
    }  
}