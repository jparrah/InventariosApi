using AutoMapper;
using static InventariosApi.Mensajeria.Command.Area;
using InventariosApi.Entidades;
using static InventariosApi.Mensajeria.Queries.Area;

namespace InventariosApi.Handlers.Command
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CrearAreaRequest, Area>();
            CreateMap<Area, ObtenerAreaResponse>();
        }
    }
}
