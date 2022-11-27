using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Orden;

namespace InventariosApi.Handlers.Queries
{
    public class OrdenQueriesHandlers : IRequestHandler<ListarOrdenRequest, IEnumerable<ListarOrdenResponse>>,
                                      IRequestHandler<ObtenerOrdenRequest, ObtenerOrdenResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public OrdenQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarOrdenResponse>> Handle(ListarOrdenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerOrdenResponse> Handle(ObtenerOrdenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
