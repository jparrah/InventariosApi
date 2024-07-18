using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Equipo;

namespace InventariosApi.Handlers.Queries
{
    public class EquipoQueriesHandlers : IRequestHandler<ListarEquiposRequest, IEnumerable<ListarEquiposResponse>>,
                                       IRequestHandler<ObtenerEquipoRequest, ObtenerEquipoResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public EquipoQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ListarEquiposResponse>> Handle(ListarEquiposRequest request, CancellationToken cancellationToken)
        {
            var equipos = await _context.Equipos.ToListAsync();
            var listarEquiposResponse = new List<ListarEquiposResponse>();
            foreach (var e in equipos)
            {
                var xx = _mapper.Map<ListarEquiposResponse>(e);
                listarEquiposResponse.Add(xx);
            }
            return listarEquiposResponse.AsEnumerable();
        }

        public async Task<ObtenerEquipoResponse> Handle(ObtenerEquipoRequest request, CancellationToken cancellationToken)
        {
            var equipo = _context.Equipos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerEquipoResponse>(equipo);

        }
    }
}
