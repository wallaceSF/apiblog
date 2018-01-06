using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using apiblog.Context;
using apiblog.Interfaces;
using apiblog.Services;

namespace apiblog.Factories
{
    public class GenericServiceFactory<T> : IGenericService<T>
        where T : class
    {
        public T GetService()
        {
            return (T)Activator.CreateInstance(typeof(T), new ContextData());           
        }
    }
}