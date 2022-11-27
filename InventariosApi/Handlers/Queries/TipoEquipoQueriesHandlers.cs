using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.TipoEquipo;

namespace InventariosApi.Handlers.Queries
{
    public class TipoEquipoQueriesHandlers : IRequestHandler<ListarTipoEquipoRequest, IEnumerable<ListarTipoEquipoResponse>>,
                                           IRequestHandler<ObtenerTipoEquipoRequest, ObtenerTipoEquipoResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public TipoEquipoQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarTipoEquipoResponse>> Handle(ListarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerTipoEquipoResponse> Handle(ObtenerTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
