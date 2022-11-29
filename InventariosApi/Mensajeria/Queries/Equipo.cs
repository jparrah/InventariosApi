using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Equipo
    {
        public record ListarEquiposRequest():IRequest<IEnumerable<ListarEquiposResponse>>;

        public class ListarEquiposResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
            public string NombreArea { get; set; }
            public string NombreTipoEquipo { get; set; }
            public string NombreSucursal { get; set; }
            public long Inventario { get; set; }
            public float Valor { get; set; }
            public float Depreciacion { get; set; }

            public long Sello { get; set; }

            public IEnumerable<ListarComponentesResponse> Componentes { get; set; }
        }
        public class ListarComponentesResponse
        {
            public int Id { get; set; }
            public string NombreEquipo { get;}
            public string Serie { get;}
            public  string Nombre { get; set; }
            public string Modelo { get;}
        }

        public record ObtenerEquipoRequest(int Id):IRequest<ObtenerEquipoResponse>;

        public class ObtenerEquipoResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
            public string NombreArea { get; set; }
            public string NombreTipoEquipo { get; set; }
            public string NombreSucursal { get; set; }
            public long Inventario { get; set; }
            public float Valor { get; set; }
            public float Depreciacion { get; set; }

            public long Sello { get; set; }

            public IEnumerable<ListarComponentesResponse> Componentes { get; set; }
        }
    }
    
}
