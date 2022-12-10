using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Sucursal;
using static InventariosApi.Mensajeria.Queries.Tecnico;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class TecnicoController : Controller
    {
        private readonly IMediator _mediator;
        public TecnicoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ListarTecnicos")]
        [ProducesResponseType(typeof(IEnumerable<ListarTecnicosResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarTecnicos([FromBody] ListarTecnicosRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerTecnico")]
        [ProducesResponseType(typeof(ObtenerTecnicoResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerTecnico([FromBody] ObtenerTecnicoRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
