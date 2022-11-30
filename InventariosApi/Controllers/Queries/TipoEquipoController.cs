using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Queries.Tecnico;
using static InventariosApi.Mensajeria.Queries.TipoEquipo;

namespace InventariosApi.Controllers.Queries
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
        [HttpPost("ListarTipoEquipo")]
        [ProducesResponseType(typeof(IEnumerable<ListarTipoEquipoResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTipoEquipo([FromBody] ListarTipoEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerTipoEquipo")]
        [ProducesResponseType(typeof(ObtenerTipoEquipoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerTipoEquipo([FromBody] ObtenerTipoEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
