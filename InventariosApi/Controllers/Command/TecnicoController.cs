using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Sucursal;
using static InventariosApi.Mensajeria.Command.Tecnico;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : Controller
    {
        private readonly IMediator _mediator;
        public TecnicoController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("RegistrarTecnico")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarTecnico([FromBody] RegistrarTecnicoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarTecnico")]
        [ProducesResponseType(typeof(ModificarTecnicoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarTecnico([FromBody] ModificarTecnicoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarTecnico")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarTecnico([FromBody] EliminarTecnicoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
