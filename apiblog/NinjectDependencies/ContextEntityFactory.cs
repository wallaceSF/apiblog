using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using apiblog.Context;

namespace apiblog.NinjectDependencies
{
    public class ContextEntityFactory : IContext
    {            
        public ContextData GetContext()
        {
            return new ContextData();
        }
    }
}