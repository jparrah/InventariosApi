using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using static InventariosApi.Mensajeria.Queries.Area;
using static InventariosApi.Mensajeria.Queries.Defectacion;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN,USUARIO")]
    [ApiController]
    public class DefectacionController : Controller
    {
        private readonly IMediator _mediator;
        public DefectacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ListarDefectaciones")]
        [ProducesResponseType(typeof(IEnumerable<ListarDefectacionesResponse>), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ListarDefectaciones([FromBody] ListarDefectacionesRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }

        [HttpPost("ObtenerDefectaciones")]
        [ProducesResponseType(typeof(ObtenerDefectacionResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerDefectaciones([FromBody] ObtenerDefectacionRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
