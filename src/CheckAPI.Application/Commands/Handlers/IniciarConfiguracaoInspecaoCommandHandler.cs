using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.Views;
using CheckAPI.Domain.Configuracoes;
using CheckAPI.Infrastructure;
using MediatR;

namespace CheckAPI.Application.Commands.Handlers
{
    public class IniciarConfiguracaoInspecaoCommandHandler(CheckAPIContext context) : IRequestHandler<IniciarConfiguracaoInspecaoCommand, BaseResult<IniciarConfiguracaoInspecaoView>>
    {
        public async Task<BaseResult<IniciarConfiguracaoInspecaoView>> Handle(IniciarConfiguracaoInspecaoCommand request, CancellationToken cancellationToken)
        {
            var configuracaoInspecao = new ConfiguracaoInspecao(request.Nome);

            await context.Set<ConfiguracaoInspecao>().AddAsync(configuracaoInspecao, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            var view = CriarView(configuracaoInspecao);

            return new BaseResult<IniciarConfiguracaoInspecaoView>(view);
        }

        private static IniciarConfiguracaoInspecaoView CriarView(ConfiguracaoInspecao configuracaoInspecao)
            => new(
                id: configuracaoInspecao.Id, 
                dataCadastro: configuracaoInspecao.DataCadastro, 
                nome: configuracaoInspecao.Nome);
    }
}
