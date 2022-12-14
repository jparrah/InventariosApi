using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Area;
using static InventariosApi.Mensajeria.Command.EquipoDefectado;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [Authorize(Roles ="ADMIN")]
    [ApiController]
    public class EquiposDefectadosController : Controller
    {
        private readonly IMediator _mediator;
        public EquiposDefectadosController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("RegistrarEquipoDefectado")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarEquipoDefectado([FromBody] RegistrarEquipoDefectadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarEquipoDefectado")]
        [ProducesResponseType(typeof(ModificarEquipoDefectadoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarEquipoDefectado([FromBody] ModificarEquipoDefectadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarEquipoDefectado")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarEquipoDefectado([FromBody] EliminarEquipoDefectadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
