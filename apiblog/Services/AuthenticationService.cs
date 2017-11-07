using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;
using System;

namespace apiblog.Services
{
    public class AuthenticationService
    {
        private Authenticate _Authenticate;

        public AuthenticationService(Authenticate Authenticate)
        {
            _Authenticate = Authenticate;
        }

        public bool Authenticate()
        {
            var UsuarioServices = new UsuarioServices(new ContextData());

            Usuario Usuario = UsuarioServices.GetByUserName(_Authenticate.Username);

            if (Usuario == null)
            {
                throw new NullReferenceException("Não foi encontrado o usuário");
            }

            if(CheckPassword(Usuario, _Authenticate.Password))
            {
                return true;
            }

            return false;
        }

        private bool CheckPassword(Usuario Usuario, string Password)
        {
           if(Usuario.Senha != Password)
            {
                return false;
            }

            return true;
        }
    }
}