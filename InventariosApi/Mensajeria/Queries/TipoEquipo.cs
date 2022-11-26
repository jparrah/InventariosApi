using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class TipoEquipo
    {
        public record ListarTipoEquipoRequest():IRequest<IEnumerable<ListarTipoEquipoResponse>>;

        public class ListarTipoEquipoResponse
        {
            public int Id { get; set; }
            public string NombreTipoEquipo { get; set; }
        }
        public record ObtenerTipoEquipoRequest(int Id):IRequest<ObtenerTipoEquipoRequest>;

        public class ObtenerTipoEquipoResponse
        {
            public int Id { get; set; }
            public string NombreTipoEquipo { get; set; }
        }
    }
}
