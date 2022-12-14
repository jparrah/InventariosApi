using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Labores;
using static InventariosApi.Mensajeria.Queries.Orden;

namespace InventariosApi.Handlers.Queries
{
    public class OrdenQueriesHandlers : IRequestHandler<ListarOrdenRequest, IEnumerable<ListarOrdenResponse>>,
                                      IRequestHandler<ObtenerOrdenRequest, ObtenerOrdenResponse>,
                                      IRequestHandler<ListarOrdenFechaTecnicoEstadoRequest,IEnumerable<ListarOrdenResponse>>,
                                      IRequestHandler<ListarOrdenFechaInventarioEstadoRequest, IEnumerable<ListarOrdenResponse>>

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

        public async Task<IEnumerable<ListarOrdenResponse>> Handle(ListarOrdenFechaTecnicoEstadoRequest request, CancellationToken cancellationToken)
        {
            var ordenesFechaTecnicoEstado = _context.Ordenes.Where(x => x.FechaEntrada > request.fechaInicial &&
                                          x.FechaEntrada < request.fechaFinal && 
                                          x.TecnicoId == request.tecnicoId &&
                                          x.EquiposDefectados.Estado.NombreEstado==request.estado).ToList();
            var listarOrdenResponse=new List<ListarOrdenResponse>();
            foreach (var item in ordenesFechaTecnicoEstado)
            {
                var xx = _mapper.Map<ListarOrdenResponse>(item);
                listarOrdenResponse.Add(xx);
            }
            return listarOrdenResponse.AsEnumerable();
        }

        public async Task<IEnumerable<ListarOrdenResponse>> Handle(ListarOrdenFechaInventarioEstadoRequest request, CancellationToken cancellationToken)
        {
            var ordenesFechaInventarioEstado = _context.Ordenes.Where(x => x.FechaEntrada > request.fechaInicial &&
                                          x.FechaEntrada < request.fechaFinal &&
                                          x.EquiposDefectados.Inventario == request.inventario &&
                                          x.EquiposDefectados.Estado.NombreEstado == request.estado).ToList();
            var listarOrdenResponse = new List<ListarOrdenResponse>();
            foreach (var item in ordenesFechaInventarioEstado)
            {
                var xx = _mapper.Map<ListarOrdenResponse>(item);
                listarOrdenResponse.Add(xx);
            }
            return listarOrdenResponse.AsEnumerable();

        }
    }
}
