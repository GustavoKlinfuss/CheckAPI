using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.ConfiguracoesInspecao;
using CheckAPI.Application.Commands.ConfiguracoesInspecao.Views;
using CheckAPI.DataContracts.ConfiguracaoInspecoes;
using CheckAPI.Domain.Configuracoes;
using CheckAPI.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckAPI.Controllers
{
    [ApiController]
    [Route("v1/configuracoes")]
    public class GerenciamentoInspecoesV1Controller(IConfiguration config, IMediator _mediator, CheckAPIContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Iniciar(IniciarConfiguracaoInspecaoV1Request request)
        {
            var command = new IniciarConfiguracaoInspecaoCommand(request.Nome);
            var result = await _mediator.Send(command);

            if (result.Sucesso)
                return Created((result.Dados as IniciarConfiguracaoInspecaoView)!.Id.ToString(), result);

            return result.Erros?.FirstOrDefault()?.Codigo == CommonErrors.ERRO_VALIDACAO
                ? BadRequest(result)
                : UnprocessableEntity(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDetalheConfiguracao(Guid? id)
        {
            var configuracaoInspecao = await context.Set<ConfiguracaoInspecao>().Include(x => x.Inspecionaveis).FirstOrDefaultAsync(x => x.Id == id);

            if (configuracaoInspecao is null)
                return NotFound(new BaseResult(new List<CommandExecutionError> { new(CommonErrors.REGISTRO_NAO_ENCONTRADO, "O registro não foi encontrado") }));

            return Ok(
                new BaseResult(
                    new ObterDetalhesConfiguracaoInspecaoV1View(
                        configuracaoInspecao.Id, 
                        configuracaoInspecao.Nome, 
                        configuracaoInspecao.Inspecionaveis.Select(x => new ObterDetalhesConfiguracaoInspecaoV1View.Inspecionavel(
                            x.Id, 
                            x.Titulo, 
                            x.Descricao, 
                            (int)x.TipoPreenchimento,
                            (int)x.ConfigObservacao)))));
        }

        [HttpGet]
        public async Task<IActionResult> ObterConfiguracoes()
        {
            var configuracaoInspecao = await context.Set<ConfiguracaoInspecao>().ToListAsync();

            var configuracoesViewListed = configuracaoInspecao.Select(x => new ObterConfiguracoesInspecaoV1View.ConfiguracaoInspecao(x.Id));
            var view = new ObterConfiguracoesInspecaoV1View(configuracoesViewListed);

            return Ok(new BaseResult(view));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var command = new RemoverConfiguracaoInspecaoCommand(id);
            var result = await _mediator.Send(command);

            return result.Sucesso
                ? NoContent()
                : result.Erros?.FirstOrDefault()?.Codigo == CommonErrors.ERRO_VALIDACAO
                    ? BadRequest(result)
                    : UnprocessableEntity(result);
        }

        [HttpPatch("{id}/inspecionavel")]
        public async Task<IActionResult> AdicionarInspecionavel(Guid id, AdicionarInspecionavelV1Request request)
        {
            var command = new AdicionarInspecionavelCommand(
                id,
                request.Titulo,
                request.Descricao,
                request.TipoPreenchimento,
                request.ConfiguracaoObservacao
                );
            var result = await _mediator.Send(command);

            return result.Sucesso
                ? Created((result.Dados as AdicionarInspecionavelView)!.Id.ToString(), result)
                : result.Erros?.FirstOrDefault()?.Codigo == CommonErrors.ERRO_VALIDACAO
                    ? BadRequest(result)
                    : UnprocessableEntity(result);
        }
    }
}
