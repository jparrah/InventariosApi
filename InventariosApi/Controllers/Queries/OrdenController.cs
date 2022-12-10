using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Labores;
using static InventariosApi.Mensajeria.Queries.Orden;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class OrdenController : Controller
    {
        private readonly IMediator _mediator;
        public OrdenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ListarOrdenes")]
        [ProducesResponseType(typeof(IEnumerable<ListarOrdenResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarOrdenes([FromBody] ListarOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ListarOrdenesFechaTecnicoEstado")]
        [ProducesResponseType(typeof(IEnumerable<ListarOrdenResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarOrdenesFechaTecnicoEstado([FromBody] ListarOrdenFechaTecnicoEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ListarOrdenesFechaInventarioEstado")]
        [ProducesResponseType(typeof(IEnumerable<ListarOrdenResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarOrdenesFechaInventarioEstado([FromBody] ListarOrdenFechaInventarioEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerOrden")]
        [ProducesResponseType(typeof(ObtenerOrdenResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerOrden([FromBody] ObtenerOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
