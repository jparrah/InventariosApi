using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Estado;
using static InventariosApi.Mensajeria.Queries.Labores;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class LaboresController : Controller
    {
        private readonly IMediator _mediator;
        public LaboresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("ListarLabores")]
        [ProducesResponseType(typeof(IEnumerable<ListarLaboresResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarLabores([FromBody] ListarLaboresRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerLabor")]
        [ProducesResponseType(typeof(ObtenerLaborResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerLabor([FromBody] ObtenerLaborRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
