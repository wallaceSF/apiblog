﻿using System.Collections.Generic;
using System.Web.Http;

using apiblog.Entities;
using apiblog.Services;
using apiblog.Interfaces;
using apiblog.Filters;

namespace apiblog.Controllers
{
    public class PessoaController : ApiController
    {        
        private IGenericService<PessoaServices> _pessoaService;        

        public PessoaController(IGenericService<PessoaServices> pessoaService)
        {            
            _pessoaService = pessoaService;            
        }
              
        public IEnumerable<Pessoa> Get()
        {            
            return _pessoaService.GetService().GetAll();                 
        }

        public dynamic Get(int id)
        { 
            return _pessoaService.GetService().Get(id);
        }
         
        public void Post([FromBody]Pessoa pessoa)
        {                      
            _pessoaService.GetService().Create(pessoa);
        }

        public void Put(int id, [FromBody]Pessoa pessoa)
        {            
            _pessoaService.GetService().Update(id, pessoa);
        }
        
        public void Delete(int id)
        {                    
            _pessoaService.GetService().Delete(id);
        }
        
    }
}
