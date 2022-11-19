using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Area
    {
        public record CrearAreaRequest( int Id,string Nombre):IRequest<bool>;

        public record ModificarAreaRequest(int id,string Nombre):IRequest<ModificarAreaResponse>;

        public class ModificarAreaResponse
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
        public record EliminarAreaRequest(int Id):IRequest<bool>;
    }
}
