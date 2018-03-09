using apiblog.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiblog.Validation
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(pessoa => pessoa.Nome).NotEmpty().WithMessage("Please specify a name");
            RuleFor(pessoa => pessoa.NascimentoData).NotEmpty().WithMessage("Please specify a date of birth");                        
        }
    }
}