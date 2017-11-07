using apiblog.Context;
using apiblog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiblog.Services
{
    public class UsuarioServices
    {
        private ContextData _context;

        public UsuarioServices(ContextData context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> GetAll()
        {           
            return _context.Usuario.ToList();
        }   

        public Usuario Get(int id)
        {            
            return _context.Usuario.Find(id);
        }

        public Usuario GetByUserName(string UserName)
        {
            return _context.Usuario.Where(u => u.Login == UserName).FirstOrDefault();
        }

       

    }
}

 