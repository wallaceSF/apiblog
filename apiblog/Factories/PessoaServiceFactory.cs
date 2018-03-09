using apiblog.Context;
using apiblog.Interfaces;
using apiblog.Services;
using apiblog.UoW;
using apiblog.Validation;

namespace apiblog.Factories
{
    public class PessoaServiceFactory: IPessoaService
    {
        public PessoaServices getPessoaService()
        {
            var unitOfWork = new UnitOfWork(new ContextData());
            return new PessoaServices(unitOfWork, new PessoaValidator());
        }
    }
}