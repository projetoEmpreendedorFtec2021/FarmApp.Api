using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator()
        {
            RuleFor(x => x.NomeCidade)
                .NotEmpty().WithMessage("Insira o nome da cidade");

            RuleFor(x => x.Iduf)
                .NotEqual(0).WithMessage("Insira o estado");
        }
    }
}
