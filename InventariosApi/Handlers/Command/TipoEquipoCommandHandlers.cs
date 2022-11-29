using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Tecnico;
using static InventariosApi.Mensajeria.Command.TipoEquipo;

namespace InventariosApi.Handlers.Command
{
    public class TipoEquipoCommandHandlers : IRequestHandler<RegistarTipoEquipoRequest, bool>,
                                           IRequestHandler<ModificarTipoEquipoRequest, ModificarTipoEquipoResponse>,
                                            IRequestHandler<EliminarTipoEquipoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public TipoEquipoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevoTipoEquipo = _mapper.Map<TipoEquipo>(request);
            _context.TipoEquipos.Add(nuevoTipoEquipo);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarTipoEquipoResponse> Handle(ModificarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            var tipoEquipo = _context.TipoEquipos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var tipoEquipoModificado = _mapper.Map(request, tipoEquipo);
            _context.TipoEquipos.Update(tipoEquipoModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarTipoEquipoResponse>(tipoEquipoModificado);
        }

        public async Task<bool> Handle(EliminarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var tipoEquipo = _context.TipoEquipos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.TipoEquipos.Remove(tipoEquipo);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
