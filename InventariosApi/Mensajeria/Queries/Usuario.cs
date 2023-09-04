using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class LoginUsuarioRequest:IRequest<LoginUsuarioResponse>
    {
        public string  UserName { get; set; }
        public string  Password { get; set; }

    }

    public class LoginUsuarioResponse
    {
        public string status { get; set; }
        public string token { get; set; }
        public string role { get; set; }

    }
}
