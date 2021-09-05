using FarmApp.Domain.Models;
using FluentValidation;
using System;

namespace FarmApp.Service.Validators
{
    public class ConsentimentoValidator : AbstractValidator<Consentimento>
    {
        public ConsentimentoValidator()
        {
            RuleFor(x => x.Finalidade)
                .NotEmpty().WithMessage("Insira a Finalidade");

            RuleFor(x => x.Situacao)
                .NotEmpty().WithMessage("Insira a Situação");

            RuleFor(x => x.Data)
                .NotEqual(DateTime.MinValue).WithMessage("Insira a Data");

            RuleFor(x => x.Idcliente)
                .NotEqual(0).WithMessage("Insira o IdCliente");
        }
    }
}
