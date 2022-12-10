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
    public class LoginUsuario : IRequestHandler<LoginUsuarioRequest, string>
    {
        private readonly IConfiguration _config;
        private readonly InventariosDbContext _context;
        Utiles utiles;
        public LoginUsuario(IConfiguration config, InventariosDbContext context)
        {
            _config = config;
            _context = context;
            utiles=new Utiles();
        }

        public async Task<string> Handle(LoginUsuarioRequest request, CancellationToken cancellationToken)
        {
            var pass = utiles.GetSha256Hash(request.Password);
            var usuarioLogueado=_context.Usuarios.Where(x=>x.UserName==request.UserName.ToLower()
                                                        && x.Password==pass.ToLower())
                                                        .FirstOrDefault();
            if (usuarioLogueado == null) {


                
            }
            
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                var credentials= new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

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

               return new JwtSecurityTokenHandler().WriteToken(token);
            
            
        }
    }
}
