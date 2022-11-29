using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Estado;
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

        public async Task<IEnumerable<ListarLaboresResponse>> Handle(ListarLaboresRequest request, CancellationToken cancellationToken)
        {
            var labores = await _context.Labores.ToListAsync();
            var listarLaboresResponse = new List<ListarLaboresResponse>();
            foreach (var l in labores)
            {
                var xx = _mapper.Map<ListarLaboresResponse>(l);
                listarLaboresResponse.Add(xx);
            }
            return listarLaboresResponse.AsEnumerable();
        }

        public async Task<ObtenerLaborResponse> Handle(ObtenerLaborRequest request, CancellationToken cancellationToken)
        {
            var labor = _context.Labores.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerLaborResponse>(labor);
        }
    }
}
