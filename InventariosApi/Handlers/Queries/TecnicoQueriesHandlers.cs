using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Tecnico;

namespace InventariosApi.Handlers.Queries
{
    public class TecnicoQueriesHandlers : IRequestHandler<ListarTecnicosRequest, IEnumerable<ListarTecnicosResponse>>,
                                        IRequestHandler<ObtenerTecnicoRequest, ObtenerTecnicoResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public TecnicoQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarTecnicosResponse>> Handle(ListarTecnicosRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerTecnicoResponse> Handle(ObtenerTecnicoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
