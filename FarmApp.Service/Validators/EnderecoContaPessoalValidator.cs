using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class EnderecoContaPessoalValidator : AbstractValidator<EnderecoContapessoal>
    {
        public EnderecoContaPessoalValidator()
        {
            RuleFor(x => x.IdtipoEndereco)
                .NotEqual(0).WithMessage("Insira o IdTipoEndereco");
            
            RuleFor(x => x.Idcep)
                .NotEqual(0).WithMessage("Insira o IdCep");
            
            RuleFor(x => x.IdcontaPessoal)
                .NotEqual(0).WithMessage("Insira o IdContaPessoal");
        }
    }
}
