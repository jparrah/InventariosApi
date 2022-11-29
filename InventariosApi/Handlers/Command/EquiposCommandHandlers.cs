using AutoMapper;
using InventariosApi.Entidades;
using InventariosApi.Mensajeria.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static InventariosApi.Mensajeria.Command.Equipos;

namespace InventariosApi.Handlers.Command
{
    public class EquiposCommandHandlers : IRequestHandler<RegistarModificarEquiposRequest, RegistrarModificarEquipoResponse>,
                                        IRequestHandler<EliminarEquipoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public EquiposCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<RegistrarModificarEquipoResponse> Handle(RegistarModificarEquiposRequest request, CancellationToken cancellationToken)
        {
            var equipo=_context.Equipos.Where(x=>x.Id==request.Id).FirstOrDefault();
            if (equipo==null)
            {
                var nuevoEquipo = _mapper.Map<Equipos>(request);
                _context.Equipos.Add(nuevoEquipo);
                foreach (var item in request.Componentes)
                {
                    var nuevoComponente = _mapper.Map<Componente>(item);
                    nuevoEquipo.Componentes.Add(nuevoComponente);
                }
                _context.SaveChanges();
                return _mapper.Map<RegistrarModificarEquipoResponse>(nuevoEquipo);
            }
            else
            {
               var equipoModificado= _mapper.Map(request,equipo);
                _context.Equipos.Update(equipoModificado);
                _context.SaveChanges();
                return _mapper.Map<RegistrarModificarEquipoResponse>(equipoModificado);

            }
        }

        public async Task<bool> Handle(EliminarEquipoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var equipo = _context.Equipos.Where(x => x.Id == request.Id).FirstOrDefault() ?? default;
            _context.Equipos.Remove(equipo);
            _context.SaveChanges();
            ok = true;
            return ok;


        }
    }
}
