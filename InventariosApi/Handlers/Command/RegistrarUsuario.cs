using InventariosApi.Entidades;
using InventariosApi.Mensajeria.Command;
using MediatR;
using System.Text;
using System.Text.RegularExpressions;

namespace InventariosApi.Handlers.Command
{
    public class RegistrarUsuario : IRequestHandler<RegistrarUsuarioRequest, RegistrarUsuarioResponse>
    {
        private readonly InventariosDbContext _context;
        public Utiles utiles;
        public RegistrarUsuario(InventariosDbContext context)
        {
            _context = context;
            utiles= new Utiles();
        }

        public async Task<RegistrarUsuarioResponse> Handle(RegistrarUsuarioRequest request, CancellationToken cancellationToken)
        {

            if(request.Email==null) { 
            
            }
            if (string.IsNullOrWhiteSpace(request.Password) ||
                request.Password.Length < 8
                || utiles.CheckStringWithoutSpecialChars(request.Password)
                || !utiles.CheckStringWithUppercaseLetters(request.Password))
            {
                
            }

            if (request.Password != request.VerificarPassword)
            {
                
            }
            var passwordHash = utiles.GetSha256Hash(request.Password);
            var usuario = new Usuario
            {
                UserName=request.Username,
                Password=passwordHash,
                Email=request.Email,
                Role=RolesEnum.USUARIO.ToString(),

            };
            _context.Add(usuario);
            _context.SaveChanges();

            var registarUsuarioResponse= new RegistrarUsuarioResponse();
            registarUsuarioResponse.Ok = true;

            return registarUsuarioResponse;


        }

       
    }
}
