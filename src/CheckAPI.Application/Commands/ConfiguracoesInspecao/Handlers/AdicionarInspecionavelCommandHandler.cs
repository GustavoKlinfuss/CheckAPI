using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.ConfiguracoesInspecao.Views;
using MediatR;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Handlers
{
    public class AdicionarInspecionavelCommandHandler : IRequestHandler<AdicionarInspecionavelCommand, BaseResult>
    {
        public Task<BaseResult> Handle(AdicionarInspecionavelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
