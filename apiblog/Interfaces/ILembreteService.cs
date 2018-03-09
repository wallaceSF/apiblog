using apiblog.Entities;
using apiblog.Services;

namespace apiblog.Interfaces
{
    public interface ILembreteService
    {
        LembreteService getLembreteService(Pessoa pessoa);
    }        
}
