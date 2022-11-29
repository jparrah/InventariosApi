using AutoMapper;
using InventariosApi.Entidades;
using static InventariosApi.Mensajeria.Queries.Area;
using static InventariosApi.Mensajeria.Queries.Defectacion;
using static InventariosApi.Mensajeria.Queries.Equipo;
using static InventariosApi.Mensajeria.Queries.Estado;
using static InventariosApi.Mensajeria.Queries.Labores;
using static InventariosApi.Mensajeria.Queries.Orden;
using static InventariosApi.Mensajeria.Queries.Sucursal;
using static InventariosApi.Mensajeria.Queries.Tecnico;
using static InventariosApi.Mensajeria.Queries.TipoEquipo;

namespace InventariosApi.Handlers.Queries
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Area, ListarAreasResponse>();
            CreateMap<Area, ObtenerAreaResponse>();
            CreateMap<Defectacion, ListarDefectacionesResponse>();
            CreateMap<Defectacion, ObtenerDefectacionResponse>();

            CreateMap<Equipos, ListarEquiposResponse>()
                .ForMember(x => x.NombreEstado, opt => opt.MapFrom(x => x.EstadoId))
                .ForMember(x => x.NombreArea, opt => opt.MapFrom(x => x.AreaId))
                .ForMember(x => x.NombreTipoEquipo, opt => opt.MapFrom(x => x.TipoEquipoId))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(x => x.SucursalId));

            CreateMap<Equipos, ObtenerEquipoResponse>()
                .ForMember(x => x.NombreEstado, opt => opt.MapFrom(x => x.EstadoId))
                .ForMember(x => x.NombreArea, opt => opt.MapFrom(x => x.AreaId))
                .ForMember(x => x.NombreTipoEquipo, opt => opt.MapFrom(x => x.TipoEquipoId))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(x => x.SucursalId));

            CreateMap<Componente, ListarComponentesResponse>()
                .ForMember(x => x.NombreEquipo, opt => opt.MapFrom(x => x.EquiposId));

            CreateMap<Estado, ListarEstadosResponse>();
            CreateMap<Estado, ObtenerEstadoResponse>();
            CreateMap<Labores, ListarLaboresResponse>();
            CreateMap<Labores, ObtenerLaborResponse>();
            CreateMap<Orden, ListarOrdenResponse>()
                .ForMember(x => x.NombreEquipo, opt => opt.MapFrom(x => x.EquiposId))
                .ForMember(x => x.NombreTecnico, opt => opt.MapFrom(x => x.TecnicoId))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(x => x.SucursalId));

            CreateMap<Orden, ObtenerOrdenResponse>()
                .ForMember(x => x.NombreEquipo, opt => opt.MapFrom(x => x.EquiposId))
                .ForMember(x => x.NombreTecnico, opt => opt.MapFrom(x => x.TecnicoId))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(x => x.SucursalId));

            CreateMap<Sucursal, ListarSucursalesResponse>();
            CreateMap<Sucursal, ObtenerSucursalResponse>();
            CreateMap<Tecnico, ListarTecnicosResponse>()
                .ForMember(x => x.NombreUnido,opt=>opt.MapFrom(x => x.Nombre +" "+ x.PrimerApellido+" "+x.SegundoApellido));

            CreateMap<Tecnico, ObtenerTecnicoResponse>()
                .ForMember(x => x.NombreUnido, opt => opt.MapFrom(x => x.Nombre + " " + x.PrimerApellido + " " + x.SegundoApellido));

            CreateMap<TipoEquipo, ListarTipoEquipoResponse>();
            CreateMap<TipoEquipo, ObtenerTipoEquipoResponse>();
        }
    }
}
