using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Labores;

namespace InventariosApi.Handlers.Queries
{
    public class LaboresQueriesHandlers : IRequestHandler<ListarLaboresRequest, IEnumerable<ListarLaboresResponse>>,
                                        IRequestHandler<ObtenerLaborRequest, ObtenerLaborResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public LaboresQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarLaboresResponse>> Handle(ListarLaboresRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerLaborResponse> Handle(ObtenerLaborRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
