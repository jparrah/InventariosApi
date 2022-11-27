using AutoMapper;
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

        public Task<bool> Handle(RegistarDefectacionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarDefectacionResponse> Handle(ModificarDefectacionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarDefectacionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
