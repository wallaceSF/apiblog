using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using apiblog.Context;
using apiblog.Interfaces;

namespace apiblog.Factories
{
    public class ContextEntityFactory : IContext
    {            
        public ContextData GetContext()
        {
            return new ContextData();
        }
    }
}