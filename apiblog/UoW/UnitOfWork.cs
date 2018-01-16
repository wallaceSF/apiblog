using System;
using System.Data.Entity;

using apiblog.Context;
using apiblog.Entities;
using apiblog.Interfaces;
using apiblog.Repositories;

namespace apiblog.UoW
{
    public class UnitOfWork : IUnitOfWork
    {        
        private ContextData _context = null;
        private bool disposed = false;
        private GenericRepository<Pessoa> _pessoaRepository = null;
        private DbContextTransaction _transaction;

        public UnitOfWork(ContextData context)
        {
            _context = context;            
        }

        public IRepository<Pessoa> PessoaRepository
        {
            get
            {
                if (_pessoaRepository == null)
                {
                    _pessoaRepository = new PessoaRepository(_context);
                }

                return _pessoaRepository;
            }
        }

        public IRepository<T> GetGenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }                

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}