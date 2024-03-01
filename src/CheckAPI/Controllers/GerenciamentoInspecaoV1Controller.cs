using CheckAPI.Application.Base;
using CheckAPI.Application.Commands;
using CheckAPI.Domain.Configuracoes;
using CheckAPI.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckAPI.Controllers
{
    [ApiController]
    [Route("v1/configuracoes")]
    public class GerenciamentoInspecaoV1Controller(IConfiguration config, IMediator _mediator, CheckAPIContext context) : ControllerBase
    {
        public record IniciarConfiguracaoDeInspecaoRequest(string Nome);


        public class ObterConfiguracacoDePagamentoView(Guid id) : View
        {
            public Guid Id { get; set; } = id;
        }

        [HttpPost]
        public async Task<IActionResult> Iniciar(IniciarConfiguracaoDeInspecaoRequest request)
        {
            var command = new IniciarConfiguracaoInspecaoCommand(request.Nome);
            var result = await _mediator.Send(command);

            return result.Sucesso
                ? Created(result.Dados!.Id.ToString(), result)
                : UnprocessableEntity(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterConfiguracao(Guid? id)
        {
            var configuracaoInspecao = await context.Set<ConfiguracaoInspecao>().Include(x => x.Inspecionaveis).FirstOrDefaultAsync(x => x.Id == id);

            if (configuracaoInspecao is null)
                return NotFound(new BaseResult<View>(new List<CommandExecutionError> { new CommandExecutionError("NÃO ENCONTRADO", "O registro não foi encontrado") }));

            return Ok(new BaseResult<ObterConfiguracacoDePagamentoView>(new ObterConfiguracacoDePagamentoView(configuracaoInspecao.Id)));
        }

        [HttpGet]
        public IActionResult ObterConfiguracoes()
        {
            return Ok();
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
