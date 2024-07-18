using MediatR;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace InventariosApi.Mensajeria.Command
{
    public class CambiarPasswordRequest : IRequest<bool>
    {
        [Required]
        [MinLength(8)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(8)]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(8)]
        [Compare("NewPassword", ErrorMessage = "Las password deben coincidir")]
        public string VerificarPassword { get; set; }
    }
}
