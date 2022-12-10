using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Equipo;
using static InventariosApi.Mensajeria.Queries.Estado;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class EstadosController : Controller
    {
        private readonly IMediator _mediator;
        public EstadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ListarEstados")]
        [ProducesResponseType(typeof(IEnumerable<ListarEstadosResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarEstados([FromBody] ListarEstadosRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerEstados")]
        [ProducesResponseType(typeof(ObtenerEstadoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerEstados([FromBody] ObtenerEstadoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
