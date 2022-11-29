using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Labores;
using static InventariosApi.Mensajeria.Command.Orden;

namespace InventariosApi.Handlers.Command
{
    public class OrdenCommandHandlers : IRequestHandler<RegistrarOrdenRequest, bool>,
                                      IRequestHandler<ModificarOrdenRequest, ModificarOrdenResponse>,
                                      IRequestHandler<EliminarOrdenRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public OrdenCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistrarOrdenRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaOrden = _mapper.Map<Orden>(request);
            _context.Ordenes.Add(nuevaOrden);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarOrdenResponse> Handle(ModificarOrdenRequest request, CancellationToken cancellationToken)
        {
            var orden = _context.Ordenes.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var ordenModificado = _mapper.Map(request, orden);
            _context.Ordenes.Update(ordenModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarOrdenResponse>(ordenModificado);
        }

        public async Task<bool> Handle(EliminarOrdenRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var orden = _context.Ordenes.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Ordenes.Remove(orden);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
