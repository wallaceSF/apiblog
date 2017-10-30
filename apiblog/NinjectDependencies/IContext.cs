using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiblog.Context;

namespace apiblog.NinjectDependencies
{
    public interface IContext
    {
        ContextData GetContext();
    }
}
