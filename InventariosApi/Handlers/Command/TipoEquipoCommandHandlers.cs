using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Command.TipoEquipo;

namespace InventariosApi.Handlers.Command
{
    public class TipoEquipoCommandHandlers : IRequestHandler<RegistarTipoEquipoRequest, bool>,
                                           IRequestHandler<ModificarTipoEquipoRequest, ModificarTipoEquipoResponse>,
                                            IRequestHandler<EliminarTipoEquipoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _context;
        public TipoEquipoCommandHandlers(IMapper mapper, InventariosDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> Handle(RegistarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarTipoEquipoResponse> Handle(ModificarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarTipoEquipoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
