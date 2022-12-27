using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Area;
using static InventariosApi.Mensajeria.Command.Defectacion;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    //[Authorize(Roles ="ADMIN")]
    [AllowAnonymous]
    [ApiController]
    public class DefectacionController : Controller
    {
        private readonly IMediator _mediator;
        public DefectacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarDefectacion")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarDefectacion([FromBody] RegistarDefectacionRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ModificarDefectacion")]
        [ProducesResponseType(typeof(ModificarDefectacionResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ModificarDefectacion([FromBody] ModificarDefectacionRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("EliminarDefectacion")]
        [ProducesResponseType(typeof(bool), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarDefectacion([FromBody] EliminarDefectacionRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
