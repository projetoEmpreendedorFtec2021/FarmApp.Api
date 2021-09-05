using FarmApp.Domain.Models;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.NomeEndereco)
                .NotEmpty().WithMessage("Insira o nome do endereço");
            
            RuleFor(x => x.Idcidade)
                .NotEqual(0).WithMessage("Insira a cidade");
            
            RuleFor(x => x.Idbairro)
                .NotEqual(0).WithMessage("Insira o bairro");

        }
    }
}
