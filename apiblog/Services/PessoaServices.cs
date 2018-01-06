using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;

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
            var Pessoa = _context.Pessoas.Find(id);

            if(Pessoa == null)
            {
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }

            return Pessoa;
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
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
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
                var NullReferenceException = new NullReferenceException("Não foi encontrado a pessoa");
                NullReferenceException.Data.Add("statusCode", HttpStatusCode.BadRequest);

                throw NullReferenceException;
            }

            _context.Pessoas.Remove(pessoaObject);
            _context.SaveChanges();

        }

    }
}

 