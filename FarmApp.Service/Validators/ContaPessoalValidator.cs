using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ContaPessoalValidator : AbstractValidator<ContaPessoal>
    {
        public ContaPessoalValidator()
        {
            RuleFor(x => x.TemFarmacia)
                .NotEmpty().WithMessage("Insira se a conta pessoal tem conta farmácia");
        }
    }
}
