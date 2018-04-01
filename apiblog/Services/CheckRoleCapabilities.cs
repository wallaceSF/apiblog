using System;

using apiblog.Context;

namespace apiblog.Services
{
    public class CheckRoleCapabilities
    {
        public ContextData context = new ContextData();

        public CheckRoleCapabilities(string request, int arguments, string controllerName)
        {
            if(request == "POST" && arguments == 1)
            {
                checkCapabilitiesCreate(controllerName);
            }

            if (request == "PUT" && arguments == 2)
            {
                checkCapabilitiesUpdate(controllerName);
            }

            if (request == "PATCH" && arguments == 2)
            {
                checkCapabilitiesUpdate(controllerName);
            }

            if (request == "DELETE" && arguments == 1)
            {
                checkCapabilitiesDelete(controllerName);
            }
        }

        private void checkCapabilitiesDelete(string controllerName)
        {            
            throw new NotImplementedException();
        }

        private void checkCapabilitiesCreate(string controllerName)
        {
            throw new NotImplementedException();
        }

        private void checkCapabilitiesUpdate(string controllerName)
        {
            throw new NotImplementedException();
        }
    }
}