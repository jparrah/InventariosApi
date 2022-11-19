using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Area;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IMediator _mediator;
        public AreaController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost("CrearArea")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> CrearArea([FromBody] CrearAreaRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarArea")]
        [ProducesResponseType(typeof(ModificarAreaResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarArea([FromBody] ModificarAreaRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarArea")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarArea([FromBody] EliminarAreaRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
