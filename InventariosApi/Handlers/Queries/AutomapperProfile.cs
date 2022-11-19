using AutoMapper;
using InventariosApi.Entidades;
using static InventariosApi.Mensajeria.Queries.Area;

namespace InventariosApi.Handlers.Queries
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Area, ListarAreasResponse>();
            CreateMap<Area, ObtenerAreaResponse>();
        }
    }
}
