using System.Collections.Generic;
using System.Web.Http;

using apiblog.Entities;
using apiblog.Interfaces;

namespace apiblog.Controllers
{
    public class PessoaController : ApiController
    {                
        private IPessoaService _pessoaService;        

        public PessoaController(IPessoaService pessoaService)
        {            
            _pessoaService = pessoaService;            
        }
              
        public IEnumerable<Pessoa> Get()
        {                    
            return _pessoaService.getPessoaService().GetAll();                 
        }

        public dynamic Get(int id)
        { 
            return _pessoaService.getPessoaService().Get(id);
        }
         
        public void Post([FromBody]Pessoa pessoa)
        {          
            _pessoaService.getPessoaService().Create(pessoa);
        }

        public void Put(int id, [FromBody]Pessoa pessoa)
        {            
            _pessoaService.getPessoaService().Update(id, pessoa);
        }
        
        public void Delete(int id)
        {                    
            _pessoaService.getPessoaService().Delete(id);
        }
        
    }
}
