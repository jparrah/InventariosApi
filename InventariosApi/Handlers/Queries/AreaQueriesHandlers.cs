using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Area;

namespace InventariosApi.Handlers.Queries
{
    public class AreaQueriesHandlers:IRequestHandler<ListarAreasRequest,IEnumerable<ListarAreasResponse>>,
                              IRequestHandler<ObtenerAreaRequest,ObtenerAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public AreaQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ListarAreasResponse>> Handle(ListarAreasRequest request, CancellationToken cancellationToken)
        {
            var areas = await _context.Area.ToListAsync();
            var ListarAreasResponse=new List<ListarAreasResponse>();
            foreach (var area in areas)
            {
                var xx = _mapper.Map<ListarAreasResponse>(area);
                ListarAreasResponse.Add(xx);
            }
            return ListarAreasResponse.AsEnumerable();
        }

        public async Task<ObtenerAreaResponse> Handle(ObtenerAreaRequest request, CancellationToken cancellationToken)
        {
            var area =  _context.Area.Where(x => x.Id == request.Id).FirstOrDefault();
            var obtenerAreaResponse=_mapper.Map<ObtenerAreaResponse>(area);

            return obtenerAreaResponse;
        }
    }
}
