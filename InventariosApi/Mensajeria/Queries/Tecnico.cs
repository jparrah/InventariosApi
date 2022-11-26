using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Tecnico
    {
        public record ListarTecnicosRequest():IRequest<IEnumerable<ListarTecnicosResponse>>;

        public class ListarTecnicosResponse
        {
            public int Id { get; set; }

            public long CI { get; set; }

            public string NombreUnido { get; set; }

        }

        public record ObtenerTecnicoRequest(int Id):IRequest<ObtenerTecnicoResponse>;

        public class ObtenerTecnicoResponse
        {
            public int Id { get; set; }
            public long CI { get; set; }

            public string NombreUnido { get; set; }
        }

    }
}
