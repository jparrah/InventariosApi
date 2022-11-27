using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Command.Estado;

namespace InventariosApi.Handlers.Command
{
    public class EstadoCommandHandlers : IRequestHandler<RegistarEstadoRequest, bool>,
                                       IRequestHandler<ModificarEstadoRequest, ModificarEstadoResponse>,
                                       IRequestHandler<EliminarEstadoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public EstadoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> Handle(RegistarEstadoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarEstadoResponse> Handle(ModificarEstadoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarEstadoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
