using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Command.Sucursal;

namespace InventariosApi.Handlers.Command
{
    public class SucursalCommandHandlers : IRequestHandler<RegistarSucursalRequest, bool>,
                                         IRequestHandler<ModificarSucursalRequest, ModificarSucursalResponse>,
                                        IRequestHandler<EliminarSucursalRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public SucursalCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> Handle(RegistarSucursalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarSucursalResponse> Handle(ModificarSucursalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarSucursalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
