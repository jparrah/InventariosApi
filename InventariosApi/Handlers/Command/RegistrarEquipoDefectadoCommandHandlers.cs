using AutoMapper;
using InventariosApi.Entidades;
using InventariosApi.Mensajeria.Command;
using MediatR;
using static InventariosApi.Mensajeria.Command.EquipoDefectado;

namespace InventariosApi.Handlers.Command
{
    public class RegistrarEquipoDefectadoCommandHandlers : IRequestHandler<RegistrarEquipoDefectadoRequest, bool>,
                                                           IRequestHandler<ModificarEquipoDefectadoRequest,ModificarEquipoDefectadoResponse>,
                                                           IRequestHandler<EliminarEquipoDefectadoRequest,bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public RegistrarEquipoDefectadoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper= mapper;
            _context= context;
        }
        public async Task<bool> Handle(RegistrarEquipoDefectadoRequest request, CancellationToken cancellationToken)
        {
            var registro = false;
            var equipo=_context.Equipos.FirstOrDefault(x=>x.Id==request.EquipoId);
            var equipoDefectado = new EquiposDefectados();
            equipoDefectado.EstadoId = request.EstadoId;
            equipoDefectado.AreaId= equipo.AreaId;
            equipoDefectado.TipoEquipoId=equipo.TipoEquipoId;
            equipoDefectado.SucursalId=equipo.SucursalId;
            equipoDefectado.Inventario=equipo.Inventario;
            equipoDefectado.DefectacionId=request.DefectacionId;
            equipoDefectado.Sello = request.NuevoSello;
            equipoDefectado.FechaReparada = request.FechaDefectada;
            equipoDefectado.FechaSalida = request.FechaSalida;
            equipoDefectado.Componentes=equipo.Componentes;
            equipoDefectado.Labores = (ICollection<Entidades.Labores>)request.Labores;

            equipo.EstadoId=request.EstadoId;
            equipo.Sello = request.NuevoSello;
            _context.EquiposDefectados.Add(equipoDefectado);
            _context.Equipos.Update(equipo);

            _context.SaveChanges();
             
            

            return registro;

        }

        public async Task<ModificarEquipoDefectadoResponse> Handle(ModificarEquipoDefectadoRequest request, CancellationToken cancellationToken)
        {
            var equipoDefectado=_context.EquiposDefectados.FirstOrDefault(x=>x.Id==request.Id);
            var equipoDefectadoModificado=_mapper.Map(request,equipoDefectado);
            _context.EquiposDefectados.Update(equipoDefectadoModificado);
            _context.SaveChanges();
            return _mapper.Map<ModificarEquipoDefectadoResponse>(equipoDefectadoModificado);
        }

        public async Task<bool> Handle(EliminarEquipoDefectadoRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var equipoDefectado=_context.EquiposDefectados.FirstOrDefault(x=>x.Id==request.Id);
            _context.EquiposDefectados.Remove(equipoDefectado);
            _context.SaveChanges();
            ok = true;
            return ok;

        }
    }
}
