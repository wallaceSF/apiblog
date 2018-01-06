using System.Web.Http;

using apiblog.Interfaces;
using apiblog.Services;

namespace apiblog.Controllers
{
    public class LembreteController : ApiController
    {   
        private IContext _context;

        public LembreteController(IContext context)
        {
            _context = context;
        }

        public dynamic Get(int idPessoa)
        {
            var pessoa = _context.GetContext().Pessoas.Find(idPessoa);  
            
            LembreteService lembreteServices = new LembreteService(pessoa);
            return lembreteServices.GetLembrete();                      
        }
        
    }
}
