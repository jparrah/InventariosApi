using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Command.Sucursal;
using static InventariosApi.Mensajeria.Command.Tecnico;

namespace InventariosApi.Handlers.Command
{
    public class TecnicoCommandHandlers : IRequestHandler<RegistrarTecnicoRequest, bool>,
                                        IRequestHandler<ModificarTecnicoRequest, ModificarTecnicoResponse>,
                                        IRequestHandler<EliminarTecnicoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public TecnicoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistrarTecnicoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevoTecnico = _mapper.Map<Tecnico>(request);
            _context.Tecnicos.Add(nuevoTecnico);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarTecnicoResponse> Handle(ModificarTecnicoRequest request, CancellationToken cancellationToken)
        {
            var tecnico = _context.Tecnicos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var tecnicoModificado = _mapper.Map(request, tecnico);
            _context.Tecnicos.Update(tecnicoModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarTecnicoResponse>(tecnicoModificado);
        }

        public async Task<bool> Handle(EliminarTecnicoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var tecnico = _context.Tecnicos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Tecnicos.Remove(tecnico);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
