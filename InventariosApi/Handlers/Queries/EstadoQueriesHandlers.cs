using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Equipo;
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

        public async Task<IEnumerable<ListarEstadosResponse>> Handle(ListarEstadosRequest request, CancellationToken cancellationToken)
        {
            var estados = await _context.Estados.ToListAsync();
            var listarEstadosResponse = new List<ListarEstadosResponse>();
            foreach (var e in estados)
            {
                var xx = _mapper.Map<ListarEstadosResponse>(e);
                listarEstadosResponse.Add(xx);
            }
            return listarEstadosResponse.AsEnumerable();
        }

        public async Task<ObtenerEstadoResponse> Handle(ObtenerEstadoRequest request, CancellationToken cancellationToken)
        {
            var estado = _context.Estados.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerEstadoResponse>(estado);

        }
    }
}
