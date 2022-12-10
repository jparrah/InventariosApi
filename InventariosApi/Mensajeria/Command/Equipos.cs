using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Equipos
    {
        public record RegistarModificarEquiposRequest(
                 int Id,
                 int EstadoId,
                 int AreaId,
                 int TipoEquipoId,
                 int SucursalId,
                 long Inventario,
                 float Valor,
                 float Depreciacion,
                 long Sello,
                 IEnumerable<RegistrarModificarComponentesRequest> Componentes):IRequest<RegistrarModificarEquipoResponse>;

        public class RegistrarModificarEquipoResponse
        {
            public int Id { get; set; }
            public int EstadoId { get; set; }
            public int AreaId { get; set; }
            public int TipoEquipoId { get; set; }
            public int SucursalId { get; set; }
            public long Inventario { get; set; }
            public float Valor { get; set; }
            public float Depreciacion { get; set; }
            public long Sello { get; set; }
            IEnumerable<RegistrarModificarComponenteResponse> componentes { get; set; }
        }
        public class RegistrarModificarComponentesRequest
        {
            public int EquiposId { get; set; }
            public string Serie { get; set; }
            public string Nombre { get; set; }
            public string Modelo { get; set; }
        }
        public class RegistrarModificarComponenteResponse
        {
            public int Id { get; set; }
            public string NombreEquipo { get; set; }
            public string Serie { get; set; }
            public string Nombre { get; set; }
            public string Modelo { get; set; }
        }

        public record EliminarEquipoRequest(int Id):IRequest<bool>;
    }
}
