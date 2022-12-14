using AutoMapper;
using static InventariosApi.Mensajeria.Command.Area;
using InventariosApi.Entidades;
using static InventariosApi.Mensajeria.Queries.Area;
using static InventariosApi.Mensajeria.Command.Defectacion;
using static InventariosApi.Mensajeria.Command.Equipos;
using static InventariosApi.Mensajeria.Command.Estado;
using static InventariosApi.Mensajeria.Command.Labores;
using static InventariosApi.Mensajeria.Command.Orden;
using static InventariosApi.Mensajeria.Command.Sucursal;
using static InventariosApi.Mensajeria.Command.Tecnico;
using static InventariosApi.Mensajeria.Command.TipoEquipo;
using static InventariosApi.Mensajeria.Command.EquipoDefectado;

namespace InventariosApi.Handlers.Command
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<RegistrarAreaRequest, Area>();
            CreateMap<ModificarAreaRequest, Area>();
            CreateMap<Area, ModificarAreaResponse>();
            CreateMap<RegistarDefectacionRequest, Defectacion>();
            CreateMap<ModificarDefectacionRequest, Defectacion>();
            CreateMap<Defectacion, ModificarDefectacionResponse>();
            CreateMap<RegistarModificarEquiposRequest, Equipos>();
            CreateMap<Equipos, RegistrarModificarEquipoResponse>();
            CreateMap<RegistrarModificarComponentesRequest, Componente>();
            CreateMap<RegistarEstadoRequest, Estado>();
            CreateMap<ModificarEstadoRequest, Estado>();
            CreateMap<Estado, ModificarEstadoResponse>();
            CreateMap<RegistrarLaborRequest, Labores>();
            CreateMap<ModificarLaborRequest, Labores>();
            CreateMap<Labores, ModificarLaborResponse>();
            CreateMap<RegistrarOrdenRequest, Orden>();
            CreateMap<ModificarOrdenRequest, Orden>();
            CreateMap<Orden, ModificarOrdenResponse>();
            CreateMap<RegistarSucursalRequest, Sucursal>();
            CreateMap<ModificarSucursalRequest, Sucursal>();
            CreateMap<Sucursal, ModificarSucursalResponse>();
            CreateMap<RegistrarTecnicoRequest, Tecnico>();
            CreateMap<ModificarTecnicoRequest, Tecnico>();
            CreateMap<Tecnico, ModificarTecnicoResponse>();
            CreateMap<RegistarTipoEquipoRequest, TipoEquipo>();
            CreateMap<ModificarTipoEquipoRequest, TipoEquipo>();
            CreateMap<TipoEquipo, ModificarTipoEquipoResponse>();

            CreateMap<EquiposDefectados, ModificarEquipoDefectadoResponse>()
                .ForMember(x => x.NombreEstado, opt => opt.MapFrom(x => x.EstadoId))
                .ForMember(x => x.NombreArea, opt => opt.MapFrom(x => x.AreaId))
                .ForMember(x => x.NombreTipoEquipo, opt => opt.MapFrom(x => x.TipoEquipoId))
                .ForMember(x => x.NombreSucursal, opt => opt.MapFrom(x => x.SucursalId))
                .ForMember(x => x.NombreDefectacion, opt => opt.MapFrom(x => x.DefectacionId));
        }
    }
}
