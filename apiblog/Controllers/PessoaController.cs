using System.Collections.Generic;
using System.Web.Http;

using apiblog.Entities;
using apiblog.Filters;
using apiblog.Interfaces;
using apiblog.Models;

namespace apiblog.Controllers
{
    public class PessoaController : ApiController
    {                
        private IPessoaService _pessoaService;        

        public PessoaController(IPessoaService pessoaService)
        {            
            _pessoaService = pessoaService;            
        }

        [CustomAuthorize(RolesUser.Editor)]
        [RolesCapabilities]
        public IEnumerable<Pessoa> Get()
        {                    
            return _pessoaService.getPessoaService().GetAll();                 
        }

        [CustomAuthorize(RolesUser.Administrador, RolesUser.Editor)]
        [RolesCapabilities]
        public Pessoa Get(int id)
        { 
            return _pessoaService.getPessoaService().Get(id);
        }

        [CustomAuthorize(RolesUser.Editor)]
        [RolesCapabilities]
        public void Post([FromBody]Pessoa pessoa)
        {          
            _pessoaService.getPessoaService().Create(pessoa);
        }

        [RolesCapabilities]
        public void Put(int id, [FromBody]Pessoa pessoa)
        {            
            _pessoaService.getPessoaService().Update(id, pessoa);
        }

        [RolesCapabilities]
        public void Delete(int id)
        {                    
            _pessoaService.getPessoaService().Delete(id);
        }
        
    }
}
