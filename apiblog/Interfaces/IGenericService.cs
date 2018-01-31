using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiblog.Context;
using apiblog.Entities;
using apiblog.Services;

namespace apiblog.Interfaces
{
    public interface IGenericService<T>
        where T : class
    {
        T GetService();
    }        
}
