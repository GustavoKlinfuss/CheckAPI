using CheckAPI.Application.Base;
using MediatR;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Handlers
{
    public class RemoverConfiguracaoInspecaoCommandHandler : IRequestHandler<RemoverConfiguracaoInspecaoCommand, BaseResult<View>>
    {
        public Task<BaseResult<View>> Handle(RemoverConfiguracaoInspecaoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
