using AutoMapper;
using MediatR;
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

        public Task<RegistrarModificarEquipoResponse> Handle(RegistarModificarEquiposRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
