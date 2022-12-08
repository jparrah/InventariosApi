using InventariosApi.Entidades;
using InventariosApi.Mensajeria.Command;
using MediatR;
using System.Text;
using System.Text.RegularExpressions;

namespace InventariosApi.Handlers.Command
{
    public class RegistrarUsuario : IRequestHandler<RegistrarUsuarioRequest, bool>
    {
        private readonly InventariosDbContext _context;
        public Utiles utiles;
        public RegistrarUsuario(InventariosDbContext context)
        {
            _context = context;
            utiles= new Utiles();
        }

        public async Task<bool> Handle(RegistrarUsuarioRequest request, CancellationToken cancellationToken)
        {

            var ok = false;
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
                Id = 1,
                UserName=request.Username,
                Password=passwordHash,
                Email=request.Email,
                Role=RolesEnum.USUARIO.ToString(),

            };
            _context.Add(usuario);
            _context.SaveChanges();

            ok = true;
            return ok;


        }

       
    }
}
