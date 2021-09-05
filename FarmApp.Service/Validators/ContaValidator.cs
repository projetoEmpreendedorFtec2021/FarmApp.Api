using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ContaValidator : AbstractValidator<Conta>
    {
        public ContaValidator()
        {
            RuleFor(x => x.DataCriacao)
                .NotEmpty().WithMessage("Insira a data de criação da conta");
        }
    }
}
