using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ItemClienteValidator : AbstractValidator<ItemClientePoco>
    {
        public ItemClienteValidator()
        {
            RuleFor(c => c.IdCliente)
                .NotEqual(0)
                .WithMessage("Por favor, insira o IdCliente");

            RuleFor(c => c.IdProdutoMarca)
                .NotEqual(0)
                .WithMessage("Por favor, insira o IdProdutoMarca");
        }
    }
}
