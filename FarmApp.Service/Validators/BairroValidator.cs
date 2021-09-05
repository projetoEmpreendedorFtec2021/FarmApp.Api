using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class BairroValidator : AbstractValidator<Bairro>
    {
        public BairroValidator()
        {
            RuleFor(x => x.NomeBairro)
               .NotEmpty().WithMessage("Insira o nome do bairro");
        }
    }
}
