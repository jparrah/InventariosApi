using InventariosApi.Handlers.Command;
using InventariosApi.Mensajeria.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol.Plugins;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InventariosApi.Handlers.Queries
{
    public class LoginUsuario : IRequestHandler<LoginUsuarioRequest, LoginUsuarioResponse>
    {
        private readonly IConfiguration _config;
        private readonly InventariosDbContext _context;
        Utiles utiles;
        public LoginUsuario(IConfiguration config, InventariosDbContext context)
        {
            _config = config;
            _context = context;
            utiles = new Utiles();
        }

        public async Task<LoginUsuarioResponse> Handle(LoginUsuarioRequest request, CancellationToken cancellationToken)
        {
            LoginUsuarioResponse usuario;
            var pass = utiles.GetSha256Hash(request.Password);
            var usuarioLogueado = _context.Usuarios.FirstOrDefault(x => x.UserName == request.UserName.ToLower()
                                                        && x.Password == pass.ToLower());
            if (usuarioLogueado == null)
            {
                var usuarioVacio = new LoginUsuarioResponse();
                usuarioVacio.status = "";
                usuarioVacio.token = "";
                usuarioVacio.role = "";

                return usuarioVacio;
            }
            else
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioLogueado.UserName),
                    new Claim(ClaimTypes.Email,usuarioLogueado.Email),
                    new Claim(ClaimTypes.Role,usuarioLogueado.Role),

                };
                var token = new JwtSecurityToken(_config["JWT:Issuer"],
                   _config["JWT:Audience"],
                   Claims,
                   expires: DateTime.Now.AddMinutes(60),
                   signingCredentials: credentials);


                usuario = new LoginUsuarioResponse();
                usuario.status = "ok";
                usuario.token = new JwtSecurityTokenHandler().WriteToken(token);
                usuario.role = usuarioLogueado.Role;

                return usuario;
            }

            


        }
    }
}
