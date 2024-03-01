using CheckAPI.Application.Base;
using MediatR;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao
{
    public class RemoverConfiguracaoInspecaoCommand(Guid aggregateId) : IRequest<BaseResult<View>>
    {
        public Guid AggregateId { get; } = aggregateId;
    }
}
