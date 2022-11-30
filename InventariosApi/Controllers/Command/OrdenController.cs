using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Labores;
using static InventariosApi.Mensajeria.Command.Orden;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly IMediator _mediator;
        public OrdenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarOrden")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarOrden([FromBody] RegistrarOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarOrden")]
        [ProducesResponseType(typeof(ModificarOrdenResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarOrden([FromBody] ModificarOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarOrden")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarOrden([FromBody] EliminarOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
