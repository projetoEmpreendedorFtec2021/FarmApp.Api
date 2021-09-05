using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class UfValidator : AbstractValidator<Uf>
    {
        public UfValidator()
        {
            RuleFor(x => x.NomeUf)
                .NotEmpty().WithMessage("Insira o estado");
        }
    }
}
