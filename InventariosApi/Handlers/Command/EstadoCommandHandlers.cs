using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Defectacion;
using static InventariosApi.Mensajeria.Command.Estado;

namespace InventariosApi.Handlers.Command
{
    public class EstadoCommandHandlers : IRequestHandler<RegistarEstadoRequest, bool>,
                                       IRequestHandler<ModificarEstadoRequest, ModificarEstadoResponse>,
                                       IRequestHandler<EliminarEstadoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public EstadoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistarEstadoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaEstado = _mapper.Map<Estado>(request);
            _context.Estados.Add(nuevaEstado);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarEstadoResponse> Handle(ModificarEstadoRequest request, CancellationToken cancellationToken)
        {
            var estado = _context.Estados.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var estadoModificado = _mapper.Map(request,estado);
             _context.Estados.Update(estadoModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarEstadoResponse>(estadoModificado);
        }

        public async Task<bool> Handle(EliminarEstadoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var estado = _context.Estados.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Estados.Remove(estado);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
