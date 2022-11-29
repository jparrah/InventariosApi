using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Queries.Orden;
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

        public async Task<IEnumerable<ListarSucursalesResponse>> Handle(ListarSucursalesRequest request, CancellationToken cancellationToken)
        {
            var sucursales = await _context.Sucursales.ToListAsync();
            var listarSucursalesResponse = new List<ListarSucursalesResponse>();
            foreach (var s in sucursales)
            {
                var xx = _mapper.Map<ListarSucursalesResponse>(s);
                listarSucursalesResponse.Add(xx);
            }
            return listarSucursalesResponse.AsEnumerable();
        }

        public async Task<ObtenerSucursalResponse> Handle(ObtenerSucursalRequest request, CancellationToken cancellationToken)
        {
            var sucursal = _context.Sucursales.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            return _mapper.Map<ObtenerSucursalResponse>(sucursal);
        }
    }
}
