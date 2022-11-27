using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Estado;

namespace InventariosApi.Handlers.Queries
{
    public class EstadoQueriesHandlers : IRequestHandler<ListarEstadosRequest, IEnumerable<ListarEstadosResponse>>,
                                       IRequestHandler<ObtenerEstadoRequest, ObtenerEstadoResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public EstadoQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarEstadosResponse>> Handle(ListarEstadosRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerEstadoResponse> Handle(ObtenerEstadoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
