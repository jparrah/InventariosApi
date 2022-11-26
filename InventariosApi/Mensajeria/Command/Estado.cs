using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Estado
    {
        public record RegistarEstadoRequest(int Id, string NombreEstado) : IRequest<bool>;

        public record ModificarEstadoRequest(int Id, string NombreEstado) : IRequest<ModificarEstadoResponse>;

        public class ModificarEstadoResponse
        {
            public int Id { get; set; }
            public string NombreEstado { get; set; }
        }

        public record EliminarEstadoRequest(int Id):IRequest<bool>;
    }
}
    