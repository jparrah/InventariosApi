using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Defectacion;
using static InventariosApi.Mensajeria.Command.Equipos;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : Controller
    {
        private readonly IMediator _mediator;
        public EquiposController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("RegistrarModificarEquipos")]
        [ProducesResponseType(typeof(RegistrarModificarEquipoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarModificarEquipos([FromBody] RegistarModificarEquiposRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarEquipos")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarEquipos([FromBody] EliminarEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
