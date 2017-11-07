using apiblog.Entities;
using System.Collections.Generic;

namespace apiblog.Services.Lembretes
{
    public class PostingInDraft : ILembrete
    {
        private Pessoa _Pessoa;
    
        public void SetPessoa(Pessoa Pessoa)
        {
            _Pessoa = Pessoa;
        }

        public List<string> GetLembrete()
        {
            List<string> lembretes = new List<string>
            {
                "o post tal está em rascunho"
            };

            return lembretes;
        }
    }
}