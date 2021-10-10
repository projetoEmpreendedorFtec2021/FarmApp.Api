using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ContaPessoalValidator : AbstractValidator<ContaPessoalPoco>
    {
        public ContaPessoalValidator()
        {
            RuleFor(x => x.TemFarmacia)
                .NotEmpty().WithMessage("Insira se a conta pessoal tem conta farmácia");
        }
    }
}
