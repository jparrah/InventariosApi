using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Orden;
using static InventariosApi.Mensajeria.Command.Sucursal;

namespace InventariosApi.Handlers.Command
{
    public class SucursalCommandHandlers : IRequestHandler<RegistarSucursalRequest, bool>,
                                         IRequestHandler<ModificarSucursalRequest, ModificarSucursalResponse>,
                                        IRequestHandler<EliminarSucursalRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public SucursalCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistarSucursalRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaSucursal = _mapper.Map<Sucursal>(request);
            _context.Sucursales.Add(nuevaSucursal);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarSucursalResponse> Handle(ModificarSucursalRequest request, CancellationToken cancellationToken)
        {
            var sucursal = _context.Sucursales.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var sucursalModificado = _mapper.Map(request, sucursal);
            _context.Sucursales.Update(sucursalModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarSucursalResponse>(sucursalModificado);
        }

        public async Task<bool> Handle(EliminarSucursalRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var sucursal = _context.Sucursales.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Sucursales.Remove(sucursal);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
