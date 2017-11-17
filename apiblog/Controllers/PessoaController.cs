using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiblog.Entities;
using apiblog.NinjectDependencies;
using apiblog.Services;
using Newtonsoft.Json;
using System.Web;

namespace apiblog.Controllers
{
    public class PessoaController : ApiController
    {

        private IContext _context;

        public PessoaController(IContext context)
        {
            _context = context;
        }

        public IEnumerable<Pessoa> Get()
        {
            PessoaServices pessoaServices = new PessoaServices(_context.GetContext());
            return pessoaServices.GetAll();
        }

        public Pessoa Get(int id)
        {
            PessoaServices pessoaServices = new PessoaServices(_context.GetContext());
            return pessoaServices.Get(id);
        }
         
        public void Post([FromBody]Pessoa pessoa)
        {          
            PessoaServices pessoaServices = new PessoaServices(_context.GetContext());
            pessoaServices.Create(pessoa);
        }

        public HttpResponseMessage Put(int id, [FromBody]Pessoa pessoa)
        {
            PessoaServices pessoaServices = new PessoaServices(_context.GetContext());
            pessoaServices.Update(id, pessoa);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        public HttpResponseMessage Delete(int id)
        {
            PessoaServices pessoaServices = new PessoaServices(_context.GetContext());
            pessoaServices.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
    }
}

