using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Labores
    {
        public record ListarLaboresRequest():IRequest<IEnumerable<ListarLaboresResponse>>;
        public class ListarLaboresResponse
        {
            public int Id { get; set; }
            public string NombreLabor { get; set;}
        }
        public record ObtenerLaborRequest(int Id):IRequest<ObtenerLaborResponse>;

        public class ObtenerLaborResponse
        {
            public int Id { get; set; }
            public string NombreLabor { get; set; }

        }
    }
}
