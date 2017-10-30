using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiblog.Entities;
using apiblog.NinjectDependencies;
using apiblog.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apiblog.Controllers
{
    public class PostController : ApiController
    {
        private IContext _context;

        public PostController(IContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> Get()
        {
            PostServices postServices = new PostServices(_context.GetContext());
            return postServices.GetAll();
        }

        public Post Get(int id)
        {
            PostServices postServices = new PostServices(_context.GetContext());
            return postServices.Get(id);
        }

        public HttpResponseMessage Post([FromBody]Post post)
        {
           
            PostServices postServices = new PostServices(_context.GetContext());
            postServices.Create(post);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(int id, [FromBody]Post post)
        {
            PostServices postServices = new PostServices(_context.GetContext());
            postServices.Update(id, post);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        public HttpResponseMessage Delete(int id)
        {
            PostServices postServices = new PostServices(_context.GetContext());
            postServices.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}

