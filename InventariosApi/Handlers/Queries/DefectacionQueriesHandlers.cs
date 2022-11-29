using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Area;
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

        public async Task<IEnumerable<ListarDefectacionesResponse>> Handle(ListarDefectacionesRequest request, CancellationToken cancellationToken)
        {
            var defectaciones = await _context.Defectaciones.ToListAsync();
            var ListarDefectacionesResponse = new List<ListarDefectacionesResponse>();
            foreach (var def in defectaciones)
            {
                var xx = _mapper.Map<ListarDefectacionesResponse>(def);
                ListarDefectacionesResponse.Add(xx);
            }
            return ListarDefectacionesResponse.AsEnumerable();
        }

        public async Task<ObtenerDefectacionResponse> Handle(ObtenerDefectacionRequest request, CancellationToken cancellationToken)
        {
            var defectacion = _context.Defectaciones.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return  _mapper.Map<ObtenerDefectacionResponse>(defectacion);

           
        }
    }
}
