using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiblog.Context;
using apiblog.Entities;

namespace apiblog.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Pessoa> PessoaRepository { get; }
        IRepository<T> GetGenericRepository<T>() where T : class;
        void Save();
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Dispose();
    }
}
