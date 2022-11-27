using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Defectacion;

namespace InventariosApi.Handlers.Queries
{
    public class DefectacionQueriesHandlers : IRequestHandler<ListarDefectacionesRequest, IEnumerable<ListarDefectacionesResponse>>,
                                            IRequestHandler<ObtenerDefectacionRequest, ObtenerDefectacionResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public DefectacionQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarDefectacionesResponse>> Handle(ListarDefectacionesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerDefectacionResponse> Handle(ObtenerDefectacionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
