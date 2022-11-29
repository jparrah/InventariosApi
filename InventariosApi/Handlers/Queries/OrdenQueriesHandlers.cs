using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Labores;
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

        public async Task<IEnumerable<ListarOrdenResponse>> Handle(ListarOrdenRequest request, CancellationToken cancellationToken)
        {
            var ordenes = await _context.Ordenes.ToListAsync();
            var listarOrdenesResponse = new List<ListarOrdenResponse>();
            foreach (var o in ordenes)
            {
                var xx = _mapper.Map<ListarOrdenResponse>(o);
                listarOrdenesResponse.Add(xx);
            }
            return listarOrdenesResponse.AsEnumerable();
        }

        public async Task<ObtenerOrdenResponse> Handle(ObtenerOrdenRequest request, CancellationToken cancellationToken)
        {
            var orden = _context.Ordenes.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerOrdenResponse>(orden);
        }
    }
}
