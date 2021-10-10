using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class UfValidator : AbstractValidator<UfPoco>
    {
        public UfValidator()
        {
            RuleFor(x => x.NomeUf)
                .NotEmpty().WithMessage("Insira o estado");
        }
    }
}
