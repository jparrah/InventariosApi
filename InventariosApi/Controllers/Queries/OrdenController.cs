﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Queries.Labores;
using static InventariosApi.Mensajeria.Queries.Orden;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
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

        [HttpPost("ObtenerOrden")]
        [ProducesResponseType(typeof(ObtenerOrdenResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerOrden([FromBody] ObtenerOrdenRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}