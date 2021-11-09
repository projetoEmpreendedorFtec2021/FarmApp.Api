using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ItemFarmaciaValidator : AbstractValidator<ItemFarmaciaPoco>
    {
        public ItemFarmaciaValidator()
        {
            RuleFor(x => x.IdcontaFarmacia)
                .NotEqual(0).WithMessage("IdContaFarmacia não pode ser zero");

            RuleFor(x => x.IdprodutoMarca)
                .NotEqual(0).WithMessage("IdProdutoMarca não pode ser zero");

            RuleFor(x => x.Preco)
                .GreaterThan(0)
                .WithMessage("Preço precisa ser maior que zero");
        }
    }
}
