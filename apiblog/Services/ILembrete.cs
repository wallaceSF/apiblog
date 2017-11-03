using apiblog.Entities;
using System.Collections.Generic;

namespace apiblog.Services
{
    public interface ILembrete
    {
        void SetPessoa(Pessoa Pessoa);
        List<string> GetLembrete();
    }
}