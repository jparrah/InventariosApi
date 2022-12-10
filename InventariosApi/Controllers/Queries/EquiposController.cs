using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Defectacion;
using static InventariosApi.Mensajeria.Queries.Equipo;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class EquiposController : Controller
    {
        private readonly IMediator _mediator;
        public EquiposController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ListarEquipos")]
        [ProducesResponseType(typeof(IEnumerable<ListarEquiposResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarEquipos([FromBody] ListarEquiposRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerEquipos")]
        [ProducesResponseType(typeof(ObtenerEquipoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerEquipos([FromBody] ObtenerEquipoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }

}
