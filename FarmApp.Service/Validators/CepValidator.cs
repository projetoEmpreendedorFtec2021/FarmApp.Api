using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class CepValidator : AbstractValidator<CepPoco>
    {
        public CepValidator()
        {
            RuleFor(x => x.NumeroCep)
                .NotEmpty().WithMessage("Insira o número do Cep");

            RuleFor(x => x.Idendereco)
                .NotEqual(0).WithMessage("Insira o endereço");
        }
    }
}
