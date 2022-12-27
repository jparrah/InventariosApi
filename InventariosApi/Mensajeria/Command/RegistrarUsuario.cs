using MediatR;
using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Mensajeria.Command
{
    public class RegistrarUsuarioRequest:IRequest<RegistrarUsuarioResponse>
    {
        [Required]
        public string  Username { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        //[Compare("Password",ErrorMessage ="Las password no coinciden")]
        public string VerificarPassword { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class RegistrarUsuarioResponse
    {
       public bool Ok { get; set; }
    }
}
