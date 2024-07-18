using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Area;

namespace InventariosApi.Handlers.Command
{
    public class AreaCommandHandlers : IRequestHandler<RegistrarAreaRequest, bool>,
                      IRequestHandler<ModificarAreaRequest, ModificarAreaResponse>,
                      IRequestHandler<EliminarAreaRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public AreaCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistrarAreaRequest request, CancellationToken cancellationToken)
        {
            var nuevaArea = _mapper.Map<Area>(request);
            await _context.Area.AddAsync(nuevaArea);
            _context.SaveChanges();
            var ok = true;
            return ok;

        }

        public async Task<ModificarAreaResponse> Handle(ModificarAreaRequest request, CancellationToken cancellationToken)
        {

            var area = 
                _context
                .Area
                .Where(x => x.Id == request.Id)
                .FirstOrDefault()
                ?? 
                default;

            var areaModificada = _mapper.Map(request, area);
            _context.Area.Update(areaModificada);
            _context.SaveChanges();

            return _mapper.Map<ModificarAreaResponse>(areaModificada);



        }

        public async Task<bool> Handle(EliminarAreaRequest request, CancellationToken cancellationToken)
        {
            var area = _context.Area.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Area.Remove(area);
            _context.SaveChanges();
            var ok = true;
            return ok;
        }
    }
}
