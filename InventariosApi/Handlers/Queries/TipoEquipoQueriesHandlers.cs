using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Tecnico;
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

        public async Task<IEnumerable<ListarTipoEquipoResponse>> Handle(ListarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            var tiposEquipos = await _context.TipoEquipos.ToListAsync();
            var listarTipoEquiposResponse = new List<ListarTipoEquipoResponse>();
            foreach (var t in tiposEquipos)
            {
                var xx = _mapper.Map<ListarTipoEquipoResponse>(t);
                listarTipoEquiposResponse.Add(xx);
            }
            return listarTipoEquiposResponse.AsEnumerable();
        }

        public async Task<ObtenerTipoEquipoResponse> Handle(ObtenerTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            var tipoEquipo = _context.TipoEquipos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerTipoEquipoResponse>(tipoEquipo);
        }
    }
}
