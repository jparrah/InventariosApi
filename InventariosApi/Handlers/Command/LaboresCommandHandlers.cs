using AutoMapper;
using MediatR;
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
    
        public Task<bool> Handle(RegistrarLaborRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarLaborResponse> Handle(ModificarLaborRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarLaborRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
