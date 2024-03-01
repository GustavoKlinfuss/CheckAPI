using Microsoft.AspNetCore.Mvc;

namespace CheckAPI.Controllers
{
    [ApiController]
    [Route("v1/inspecoes")]
    public class InspecoesV1Controller : ControllerBase
    {
        [HttpPost]
        public IActionResult Iniciar()
        {
            return Ok();
        }

        [HttpPost("{id}/relatorios")]
        public IActionResult InserirRelatorios(Guid? id)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Finalizar(Guid? id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Cancelar(Guid? id)
        {
            return Ok();
        }
    }
}
