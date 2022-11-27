using AutoMapper;
using MediatR;
using static InventariosApi.Mensajeria.Command.Tecnico;

namespace InventariosApi.Handlers.Command
{
    public class TecnicoCommandHandlers : IRequestHandler<RegistrarTecnicoRequest, bool>,
                                        IRequestHandler<ModificarTecnicoRequest, ModificarTecnicoResponse>,
                                        IRequestHandler<EliminarTecnicoRequest, bool>
    {
        private readonly IMapper _mapper;
        private readonly InventariosDbContext _contex;
        public TecnicoCommandHandlers(IMapper mapper, InventariosDbContext contex)
        {
            _mapper = mapper;
            _contex = contex;
        }

        public Task<bool> Handle(RegistrarTecnicoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ModificarTecnicoResponse> Handle(ModificarTecnicoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(EliminarTecnicoRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
