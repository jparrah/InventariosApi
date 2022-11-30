using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.TipoEquipo;
using static InventariosApi.Mensajeria.Queries.Area;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : Controller
    {
        private readonly IMediator _mediator;
        public AreaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ListarArea")]
        [ProducesResponseType(typeof(IEnumerable<ListarAreasResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarArea([FromBody] ListarAreasRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerArea")]
        [ProducesResponseType(typeof(ObtenerAreaResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerArea([FromBody] ObtenerAreaRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
