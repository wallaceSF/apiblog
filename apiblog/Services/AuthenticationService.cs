using apiblog.Context;
using apiblog.Entities;
using apiblog.Models;

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

            Usuario Usuario = UsuarioServices.Get(_Authenticate.Username);

            if (Usuario == null)
            {
                return false;
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