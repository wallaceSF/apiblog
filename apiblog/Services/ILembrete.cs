using apiblog.Entities;

namespace apiblog.Services
{
    public interface ILembrete
    {
        void SetPessoa(Pessoa Pessoa);
        string GetLembrete();
    }
}