using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Estado;
using static InventariosApi.Mensajeria.Command.Labores;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class LaboresController : Controller
    {
        private readonly IMediator _mediator;
        public LaboresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarLabores")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarLabores([FromBody] RegistrarLaborRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarLabores")]
        [ProducesResponseType(typeof(ModificarLaborResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarLabores([FromBody] ModificarLaborRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarLabores")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarLabores([FromBody] EliminarLaborRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
