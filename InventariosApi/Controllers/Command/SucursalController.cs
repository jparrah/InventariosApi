using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Orden;
using static InventariosApi.Mensajeria.Command.Sucursal;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : Controller
    {
        private readonly IMediator _mediator;
        public SucursalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarSucursal")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarSucursal([FromBody] RegistarSucursalRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarSucursal")]
        [ProducesResponseType(typeof(ModificarSucursalResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarSucursal([FromBody] ModificarSucursalRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarSucursal")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarSucursal([FromBody] EliminarSucursalRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
