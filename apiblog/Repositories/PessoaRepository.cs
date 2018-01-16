using apiblog.Context;
using apiblog.Entities;

namespace apiblog.Repositories
{
    public class PessoaRepository : GenericRepository<Pessoa>        
    {
        public PessoaRepository(ContextData context) : base(context)
        {

        }
    }
}