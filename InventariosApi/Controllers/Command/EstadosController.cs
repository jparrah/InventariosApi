using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Equipos;
using static InventariosApi.Mensajeria.Command.Estado;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : Controller
    {
        private readonly IMediator _mediator;
        public EstadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarEstado")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarEstado([FromBody] RegistarEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarEstado")]
        [ProducesResponseType(typeof(ModificarEstadoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarEstado([FromBody] ModificarEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarEstado")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarEstado([FromBody] EliminarEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
