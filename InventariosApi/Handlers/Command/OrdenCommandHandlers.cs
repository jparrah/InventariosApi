using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Command.Orden;

namespace InventariosApi.Handlers.Command
{
    public class OrdenCommandHandlers : IRequestHandler<RegistrarOrdenRequest, bool>,
                                      IRequestHandler<ModificarOrdenRequest, ModificarOrdenResponse>,
                                      IRequestHandler<EliminarOrdenRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public OrdenCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> Handle(RegistrarOrdenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarOrdenResponse> Handle(ModificarOrdenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarOrdenRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
