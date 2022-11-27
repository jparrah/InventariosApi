using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Queries.Sucursal;

namespace InventariosApi.Handlers.Queries
{
    public class SucursalQueriesHandlers : IRequestHandler<ListarSucursalesRequest, IEnumerable<ListarSucursalesResponse>>,
                                         IRequestHandler<ObtenerSucursalRequest, ObtenerSucursalResponse>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public SucursalQueriesHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<IEnumerable<ListarSucursalesResponse>> Handle(ListarSucursalesRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ObtenerSucursalResponse> Handle(ObtenerSucursalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
