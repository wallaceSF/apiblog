using apiblog.Context;
using apiblog.Entities;
using apiblog.Interfaces;
using apiblog.Services;
using apiblog.UoW;
using apiblog.Validation;

namespace apiblog.Factories
{
    public class LembreteServiceFactory : ILembreteService
    {
        public LembreteService getLembreteService(Pessoa pessoa)
        {            
            return new LembreteService(pessoa);
        }       
    }
}