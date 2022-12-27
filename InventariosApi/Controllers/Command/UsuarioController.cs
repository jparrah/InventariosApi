using InventariosApi.Mensajeria.Command;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static InventariosApi.Mensajeria.Command.Area;

namespace InventariosApi.Controllers.Command
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegistrarUsuario")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(RegistrarUsuarioResponse), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> RegistrarUsuario([FromBody] RegistrarUsuarioRequest request)
        {
            var respuesta = await _mediator.Send(request);
            return Ok(respuesta);
        }
    }
}
