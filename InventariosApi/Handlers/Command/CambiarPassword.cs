using InventariosApi.Mensajeria.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace InventariosApi.Handlers.Command
{
    public class CambiarPassword : IRequestHandler<CambiarPasswordRequest, bool>
    {
        private readonly InventariosDbContext _context;
        private readonly HttpContext _http;
        Utiles utiles;
        public CambiarPassword(InventariosDbContext context, HttpContext http)
        {
            _context = context;
            _http = http;
            utiles = new Utiles();
        }

        public async Task<bool> Handle(CambiarPasswordRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var identity = _http.User.Identity as ClaimsIdentity;
            if (identity.Claims == null)
            {
                return ok;
            }

            var username = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Usuarios.FirstOrDefault(x => x.UserName == username);

            var passwordHash = utiles.GetSha256Hash(request.OldPassword);

            if (passwordHash != user.Password)
            {
                return ok;
            }

            if (request.NewPassword != request.VerificarPassword)
            {
                return ok;
            }

            if (string.IsNullOrWhiteSpace(request.NewPassword) ||
                request.NewPassword.Length < 8
                || utiles.CheckStringWithoutSpecialChars(request.NewPassword)
                || !utiles.CheckStringWithUppercaseLetters(request.NewPassword))
            {
                return ok;
            }

            var newPasswordHash = utiles.GetSha256Hash(request.NewPassword);

            user.Password = newPasswordHash;

            _context.Usuarios.Update(user);
            _context.SaveChanges();
            ok = true;
            return ok;

        }


    }

}
