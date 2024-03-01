using FluentValidation;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Validators
{
    public class IniciarConfiguracaoInspecaoCommandValidator : AbstractValidator<IniciarConfiguracaoInspecaoCommand>
    {
        public IniciarConfiguracaoInspecaoCommandValidator()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .WithMessage("O Nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(50)
                .WithMessage("O Nome deve ter no máximo 50 caracteres.");
        }
    }
}
