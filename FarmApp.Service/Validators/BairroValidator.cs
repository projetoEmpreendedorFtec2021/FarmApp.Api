using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class BairroValidator : AbstractValidator<BairroPoco>
    {
        public BairroValidator()
        {
            RuleFor(x => x.NomeBairro)
               .NotEmpty().WithMessage("Insira o nome do bairro");
        }
    }
}
