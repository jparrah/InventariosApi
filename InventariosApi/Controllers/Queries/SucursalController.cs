using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Queries.Orden;
using static InventariosApi.Mensajeria.Queries.Sucursal;

namespace InventariosApi.Controllers.Queries
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
        [HttpPost("ListarSucursales")]
        [ProducesResponseType(typeof(IEnumerable<ListarSucursalesResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarSucursales([FromBody] ListarSucursalesRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerSucursal")]
        [ProducesResponseType(typeof(ObtenerSucursalResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerSucursal([FromBody] ObtenerSucursalRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
