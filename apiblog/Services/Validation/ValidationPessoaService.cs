using FluentValidation;

using apiblog.Entities;
using apiblog.Interfaces;
using apiblog.Validation;

namespace apiblog.Services.Validation
{
    public class ValidationPessoaService : IValidationService
    {
        private PessoaValidator _pessoaValidator;
        private RolesCapabilities _rolesCapabilities;

        public Pessoa ObjectValidate { private get; set; }

        public ValidationPessoaService()
        {
            _pessoaValidator = new PessoaValidator();
            _rolesCapabilities = new RolesCapabilities();
        }
      
        public bool IsValid()
        {            
            _rolesCapabilities.CheckCapabilities(ObjectValidate);
            _pessoaValidator.ValidateAndThrow(ObjectValidate);

            return true;
        }        
    }
}