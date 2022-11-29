using AutoMapper;
using InventariosApi.Entidades;
using MediatR;
using static InventariosApi.Mensajeria.Command.Defectacion;

namespace InventariosApi.Handlers.Command
{
    public class DefectacionCommandHandlers : IRequestHandler<RegistarDefectacionRequest, bool>,
                                            IRequestHandler<ModificarDefectacionRequest, ModificarDefectacionResponse>,
                                            IRequestHandler<EliminarDefectacionRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public DefectacionCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Handle(RegistarDefectacionRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var nuevaDefectacion = _mapper.Map<Defectacion>(request);
            _context.Defectaciones.Add(nuevaDefectacion);
            _context.SaveChanges();
            ok = true;
            return ok;

        }

        public async Task<ModificarDefectacionResponse> Handle(ModificarDefectacionRequest request, CancellationToken cancellationToken)
        {
            var defectacion= _context.Defectaciones.Where(x=>x.Id==request.Id).FirstOrDefault() ?? default;
            var defectacionModificada=_mapper.Map(request,defectacion);
            _context.Defectaciones.Update(defectacionModificada);
            _context.SaveChanges();
            return _mapper.Map<ModificarDefectacionResponse>(defectacionModificada);

        }

        public async Task<bool> Handle(EliminarDefectacionRequest request, CancellationToken cancellationToken)
        {
            var ok = false;
            var defectacion=_context.Defectaciones.Where(x=>x.Id==request.Id).FirstOrDefault() ?? default;
            _context.Defectaciones.Remove(defectacion);
            _context.SaveChanges();
            ok = true;
            return ok;
        }
    }
}
