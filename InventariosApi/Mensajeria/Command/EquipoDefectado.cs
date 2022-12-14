using InventariosApi.Entidades;
using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class EquipoDefectado
    {


        public record RegistrarEquipoDefectadoRequest(int EquipoId,
                                               int DefectacionId,
                                               int EstadoId,
                                               DateTime FechaDefectada,
                                               DateTime FechaSalida,
                                               string NuevoSello,
                                               IEnumerable<Labores> Labores) : IRequest<bool>;
        public record ModificarEquipoDefectadoRequest(int Id,
                                                      int EstadoId,
                                                      int AreaId,
                                                      int TipoEquipoId,
                                                      int SucursalId,
                                                      long Inventario,
                                                      int DefectacionId,
                                                      string sello,
                                                      DateTime FechaDefectada,
                                                      DateTime FechaSalida,
                                                      IEnumerable<Componente> Componentes,
                                                      IEnumerable<Labores> Labores) : IRequest<ModificarEquipoDefectadoResponse>;


        public class ModificarEquipoDefectadoResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
            public string NombreArea { get; set; }
            public string NombreTipoEquipo { get; set; }
            public string NombreSucursal { get; set; }
            public long Inventario { get; set; }
            public string NombreDefectacion { get; set; }
            public string Sello { get; set; }
            public DateTime FechaReparada { get; set; }
            public DateTime FechaSalida { get; set; }
            IEnumerable<Componente> Componentes { get; set; }
            IEnumerable<Labores> Labores { get; set; }

        }
        public record EliminarEquipoDefectadoRequest(int Id):IRequest<bool>;
    }
}   
    
   

    
