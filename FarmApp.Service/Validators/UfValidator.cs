﻿
using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class UfValidator : AbstractValidator<Uf>
    {
        public UfValidator()
        {
            RuleFor(c => c.NomeUf)
                 .NotEmpty().WithMessage("Por favor, insira o nome da UF")
                 .NotNull().WithMessage("Por favor, insira o nome da UF");
        }
    }
}
