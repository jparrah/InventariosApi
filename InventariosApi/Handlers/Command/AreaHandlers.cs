using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Area;
using InventariosApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace InventariosApi.Handlers.Command
{
    public class AreaHandlers : IRequestHandler<CrearAreaRequest, bool>,
                      IRequestHandler<ModificarAreaRequest, ModificarAreaResponse>,
                      IRequestHandler<EliminarAreaRequest, bool>
    { 
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public AreaHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(CrearAreaRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaArea=_mapper.Map<Area>(request);
            await _context.Area.AddAsync(nuevaArea);
            _context.SaveChanges();
            ok = true;
            return ok;



        }

        public async Task<ModificarAreaResponse> Handle(ModificarAreaRequest request, CancellationToken cancellationToken)
        {
            
            var area=_context.Area.Where(x => x.Id==request.id).FirstOrDefault();
           
                var areaModificada=_mapper.Map<Area>(request);
                _context.Area.Update(areaModificada);
                _context.SaveChanges();

                return _mapper.Map<ModificarAreaResponse>(areaModificada);
          
            

        }

        public async  Task<bool> Handle(EliminarAreaRequest request, CancellationToken cancellationToken)
        {
            var ok=false;
            var area=_context.Area.Where(x=>x.Id==request.Id).FirstOrDefault();
             _context.Area.Remove(area);
            _context.SaveChanges();
             ok= true;
             return ok;
        }
    }
}
