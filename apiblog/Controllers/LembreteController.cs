using System.Web.Http;
using System.Collections.Generic;

using apiblog.Interfaces;

namespace apiblog.Controllers
{
    public class LembreteController : ApiController
    {   
        private IContext _context;
        private ILembreteService _lembreteServices;

        public LembreteController(IContext context, ILembreteService lembreteServices)
        {
            _context = context;
            _lembreteServices = lembreteServices;
        }

        public List<List<string>> Get(int idPessoa)
        {
            var pessoa = _context.GetContext().Pessoas.Find(idPessoa);            
            return _lembreteServices.getLembreteService(pessoa).GetLembrete();
        }
        
    }
}
