using Azure.Identity;
using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class LoginUsuarioRequest:IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }

   
}
