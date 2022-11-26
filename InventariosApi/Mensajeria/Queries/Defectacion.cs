using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Defectacion
    {
        public record ListarDefectacionesRequest():IRequest<IEnumerable<ListarDefectacionesResponse>>;

        public class ListarDefectacionesResponse
        {
            public int Id { get; set; }
            public string NombreDefectacion { get; set; }
        }

        public record ObtenerDefectacionRequest(int Id):IRequest<ObtenerDefectacionResponse>;
        public class ObtenerDefectacionResponse
        {
            public int Id { get; set; }
            public string NombreDefectacion { get; set; }
        }
    }
}
