using AutoMapper;
using MediatR;
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

        public Task<IEnumerable<ListarEquiposResponse>> Handle(ListarEquiposRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerEquipoResponse> Handle(ObtenerEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
