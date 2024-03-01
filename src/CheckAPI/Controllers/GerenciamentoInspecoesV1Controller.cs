using CheckAPI.Application.Base;
using CheckAPI.Application.Commands;
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

            return result.Sucesso
                ? Created(result.Dados!.Id.ToString(), result)
                : UnprocessableEntity(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterDetalheConfiguracao(Guid? id)
        {
            var configuracaoInspecao = await context.Set<ConfiguracaoInspecao>().Include(x => x.Inspecionaveis).FirstOrDefaultAsync(x => x.Id == id);

            if (configuracaoInspecao is null)
                return NotFound(new BaseResult<View>(new List<CommandExecutionError> { new("NÃO ENCONTRADO", "O registro não foi encontrado") }));

            return Ok(new BaseResult<ObterDetalhesConfiguracaoInspecaoV1View>(new ObterDetalhesConfiguracaoInspecaoV1View(configuracaoInspecao.Id)));
        }

        [HttpGet]
        public async Task<IActionResult> ObterConfiguracoes()
        {
            var configuracaoInspecao = await context.Set<ConfiguracaoInspecao>().Include(x => x.Inspecionaveis).ToListAsync();

            var configuracoesViewListed = configuracaoInspecao.Select(x => new ObterConfiguracoesInspecaoV1View.ConfiguracaoInspecao(x.Id));
            var view = new ObterConfiguracoesInspecaoV1View(configuracoesViewListed);

            return Ok(new BaseResult<ObterConfiguracoesInspecaoV1View>(view));
        }

        [HttpPatch("{id}/inspecionavel")]
        public IActionResult AdicionarInspecionavel(Guid? id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid? id)
        {
            return Ok();
        }
    }
}
