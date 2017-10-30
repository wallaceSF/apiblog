using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiblog.NinjectDependencies;

namespace apiblog.Services
{
    public class PessoaServices
    {
        private ContextData _context;

        public PessoaServices(ContextData context)
        {
            _context = context;
        }

        public IEnumerable<Pessoa> GetAll()
        {           
            return _context.Pessoas.ToList();
        }   

        public Pessoa Get(int id)
        {            
            return _context.Pessoas.Find(id);
        }

        public void Create(Pessoa pessoaObjectParams)
        {
            
            Pessoa pessoaObject = new Pessoa
            {
                Nome = pessoaObjectParams.Nome
            };

            _context.Pessoas.Add(pessoaObject);
            _context.SaveChanges();
            
        }

        public void Update(int id, Pessoa pessoaObjectParams)
        {
            
            Pessoa pessoaObject = _context.Pessoas.Find(id);

            if (pessoaObject == null)
            {
                throw new NullReferenceException("Não foi encontrado a pessoa");
            }

            pessoaObject.Nome = pessoaObjectParams.Nome;

            _context.Entry(pessoaObject).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
           
            Pessoa pessoaObject = _context.Pessoas.Find(id);

            if (pessoaObject == null)
            {
                throw new NullReferenceException("Não foi encontrado a pessoa");
            }

            _context.Pessoas.Remove(pessoaObject);
            _context.SaveChanges();

        }

    }
}

 