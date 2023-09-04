using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Estado;
using static InventariosApi.Mensajeria.Command.Labores;

namespace InventariosApi.Handlers.Command
{
    public class LaboresCommandHandlers : IRequestHandler<RegistrarLaborRequest, bool>,
                                        IRequestHandler<ModificarLaborRequest, ModificarLaborResponse>,
                                        IRequestHandler<EliminarLaborRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public LaboresCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistrarLaborRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaLabor = _mapper.Map<Labores>(request);
            _context.Labores.Add(nuevaLabor);
            _context.SaveChanges();
            ok = true;
            return ok;
        }

        public async Task<ModificarLaborResponse> Handle(ModificarLaborRequest request, CancellationToken cancellationToken)
        {
            var labor = _context.Labores.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            var laborModificado = _mapper.Map(request, labor);
            _context.Labores.Update(laborModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarLaborResponse>(laborModificado);
        }

        public async Task<bool> Handle(EliminarLaborRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var labor = _context.Labores.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Labores.Remove(labor);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
