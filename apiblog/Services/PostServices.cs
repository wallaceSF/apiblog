using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiblog.Services
{
    public class PostServices
    {

        private ContextData _context;

        public PostServices(ContextData context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll()
        {            
            return _context.Posts.ToList();          
        }   

        public Post Get(int id)
        {            
            return _context.Posts.Find(id);
        }

        public void Create(Post postObjectParams)
        {
            
            Post pessoaObject = new Post
            {
                Titulo = postObjectParams.Titulo
            };

            _context.Posts.Add(pessoaObject);
            _context.SaveChanges();
            
        }

        public void Update(int id, Post postObjectParams)
        {
            
            Post postObject = _context.Posts.Find(id);

            if (postObject == null)
            {
                throw new NullReferenceException("Não foi encontrado o post");
            }

            postObject.Titulo = postObject.Titulo;

            _context.Entry(postObject).State = System.Data.Entity.EntityState.Modified;            
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            
            Post postObject = _context.Posts.Find(id);

            if (postObject == null)
            {
                throw new NullReferenceException("Não foi encontrado o post");
            }

            _context.Posts.Remove(postObject);
            _context.SaveChanges();

        }

    }
}

 