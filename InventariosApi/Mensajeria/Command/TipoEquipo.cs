using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class TipoEquipo
    {
        public record RegistarTipoEquipoRequest(int Id,string NombreTipoEquipo):IRequest<bool>;

        public record ModificarTipoEquipoRequest(int Id,string NombreTipoEquipo):IRequest<ModificarTipoEquipoResponse>;

        public class ModificarTipoEquipoResponse
        {
            public int Id { get; set; }
            public string NombreTipoEquipo { get; set; }
        }
        public record EliminarTipoEquipoRequest(int Id):IRequest<bool>;
    }
}
