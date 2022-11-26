using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Area
    {
        public record ListarAreasRequest():IRequest<IEnumerable<ListarAreasResponse>>;

        public class ListarAreasResponse
        {
            public int Id { get; set; }
            public string NombreArea { get; set; }
        }

        public record ObtenerAreaRequest(int Id):IRequest<ObtenerAreaResponse>;

        public class ObtenerAreaResponse
        {
            public int Id { get; set; }
            public string NombreArea { get; set;}
        }
    }
}
