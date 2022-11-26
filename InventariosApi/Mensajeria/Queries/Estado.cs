using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Estado
    {
        public record ListarEstadosRequest():IRequest<IEnumerable<ListarEstadosRequest>>;

        public class ListarEstadosResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
        }
        public record ObtenerEstadoRequest(int Id):IRequest<ObtenerEstadoResponse>;

        public class ObtenerEstadoResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
        }
    }
}
