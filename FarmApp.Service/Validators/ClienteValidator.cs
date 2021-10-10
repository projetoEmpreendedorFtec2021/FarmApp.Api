using FarmApp.Domain.Models.Poco;
using FluentValidation;

namespace FarmApp.Service.Validators
{
    public class ClienteValidator : AbstractValidator<ClientePoco>
    {
        public ClienteValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por favor, insira seu nome")
                .Must(c => c.Length >= 10 && c.Length <= 45).WithMessage("O nome deve ter entre 10 e 45 caracteres");

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Por favor, insira seu e-mail")
                .EmailAddress().WithMessage("Por favor, insira um e-mail válido");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Por favor, insira uma senha")
                .Must(c => c.Length >= 6 && c.Length <= 50).WithMessage("A senha deve ter entre 6 e 50 caracteres");
        }
    }
}
