using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiblog.Services
{
    public class CategoriaServices
    {

        private ContextData _context;

        public CategoriaServices(ContextData context)
        {
            _context = context;
        }    

        public IEnumerable<Categoria> GetAll()
        {                        
            return _context.Categorias.ToList();
        }
        
        public Categoria Get(int id)
        {            
            return _context.Categorias.Find(id);
        }

        public void Create(Categoria categoriaObjectParams)
        {            
            Categoria categoriaObject = new Categoria
            {
                Nome  = categoriaObjectParams.Nome,                
                IdPai = categoriaObjectParams.IdPai ?? null,                                
            };

            _context.Categorias.Add(categoriaObject);
            _context.SaveChanges();

        }

        public void Update(int id, Categoria categoriaObjectParams)
        {
            
            Categoria categoriaObject = _context.Categorias.Find(id);

            if (categoriaObject == null)
            {
                throw new NullReferenceException("Não foi encontrado a categoria");
            }

            categoriaObject.Nome  = categoriaObjectParams.Nome;
            categoriaObject.IdPai = categoriaObjectParams.IdPai ?? null;

            _context.Entry(categoriaObject).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

        }

        public void Delete(int id)
        {

            ContextData context = new ContextData();
            Categoria categoriaObject = context.Categorias.Find(id);

            if (categoriaObject == null)
            {
                throw new NullReferenceException("Não foi encontrado a categoria");
            }

            context.Categorias.Remove(categoriaObject);
            context.SaveChanges();

        }
        
    }
}

 