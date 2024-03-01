using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.ConfiguracoesInspecao.Views;
using CheckAPI.Domain.Configuracoes;
using CheckAPI.Domain.Configuracoes.Entities;
using CheckAPI.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Handlers
{
    public class AdicionarInspecionavelCommandHandler(CheckAPIContext _context) : IRequestHandler<AdicionarInspecionavelCommand, BaseResult>
    {
        public async Task<BaseResult> Handle(AdicionarInspecionavelCommand request, CancellationToken cancellationToken)
        {
            var configuracaoInspecao = await _context.Set<ConfiguracaoInspecao>()
                .Include(x => x.Inspecionaveis)
                .FirstOrDefaultAsync(x => x.Id == request.AggregateId);

            if (configuracaoInspecao is null)
                return new BaseResult(new List<CommandExecutionError> { new(CommonErrors.REGISTRO_NAO_ENCONTRADO, "A configuração de inspeção não foi encontrada") });

            var inspecionavel = new Inspecionavel(request.Titulo, request.Descricao, request.TipoPreenchimento, request.ConfiguracaoObservacao);
            configuracaoInspecao.Adicionar(inspecionavel);

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseResult(new AdicionarInspecionavelView(inspecionavel.Id));
        }
    }
}
