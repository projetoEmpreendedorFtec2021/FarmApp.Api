using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ContaValidator : AbstractValidator<ContaPoco>
    {
        public ContaValidator()
        {
            RuleFor(x => x.DataCriacao)
                .NotEmpty().WithMessage("Insira a data de criação da conta");
        }
    }
}
