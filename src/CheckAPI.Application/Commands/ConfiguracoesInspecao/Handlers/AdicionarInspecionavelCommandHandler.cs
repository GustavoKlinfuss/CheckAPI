using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.ConfiguracoesInspecao.Views;
using MediatR;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Handlers
{
    public class AdicionarInspecionavelCommandHandler : IRequestHandler<AdicionarInspecionavelCommand, BaseResult<AdicionarInspecionavelView>>
    {
        public Task<BaseResult<AdicionarInspecionavelView>> Handle(AdicionarInspecionavelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
