using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ContaFarmaciaValidator : AbstractValidator<ContaFarmaciaPoco>
    {
        public ContaFarmaciaValidator()
        {
            RuleFor(x => x.Idcep)
                .NotEqual(0).WithMessage("IdCep não pode ser 0");
        }
    }
}
