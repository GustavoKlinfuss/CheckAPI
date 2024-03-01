using CheckAPI.Application.Base;
using CheckAPI.Domain.Configuracoes.Entities;
using MediatR;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao
{
    public class AdicionarInspecionavelCommand(Guid aggregateId, string titulo, string descricao, ETipoPreenchimento tipoPreenchimento, EConfigObservacao configuracaoObservacao)
        : IRequest<BaseResult>
    {
        public Guid AggregateId { get; set; } = aggregateId;

        public string Titulo { get; set; } = titulo;
        public string Descricao { get; set; } = descricao;
        public ETipoPreenchimento TipoPreenchimento { get; set; } = tipoPreenchimento;
        public EConfigObservacao ConfiguracaoObservacao { get; set; } = configuracaoObservacao;

        public record Opcao(string Titulo);
    }
}
