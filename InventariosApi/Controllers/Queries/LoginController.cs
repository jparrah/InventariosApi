using InventariosApi.Handlers.Queries;
using InventariosApi.Mensajeria.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Queries.Area;

namespace InventariosApi.Controllers.Queries
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(string), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> Login([FromBody] LoginUsuarioRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
