using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Tecnico;
using static InventariosApi.Mensajeria.Command.TipoEquipo;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipoController : Controller
    {
        private readonly IMediator _mediator;
        public TipoEquipoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("RegistrarTipoEquipo")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarTipoEquipo([FromBody] RegistarTipoEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarTipoEquipo")]
        [ProducesResponseType(typeof(ModificarTipoEquipoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarTipoEquipo([FromBody] ModificarTipoEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarTipoEquipo")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarTipoEquipo([FromBody] EliminarTipoEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
