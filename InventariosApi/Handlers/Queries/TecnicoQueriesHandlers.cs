using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Sucursal;
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

        public async Task<IEnumerable<ListarTecnicosResponse>> Handle(ListarTecnicosRequest request, CancellationToken cancellationToken)
        {
            var tecnicos = await _context.Tecnicos.ToListAsync();
            var listarTecnicosResponse = new List<ListarTecnicosResponse>();
            foreach (var t in tecnicos)
            {
                var xx = _mapper.Map<ListarTecnicosResponse>(t);
                listarTecnicosResponse.Add(xx);
            }
            return listarTecnicosResponse.AsEnumerable();
        }

        public async Task<ObtenerTecnicoResponse> Handle(ObtenerTecnicoRequest request, CancellationToken cancellationToken)
        {
            var tecnico = _context.Tecnicos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerTecnicoResponse>(tecnico);
        }
    }
}
