using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class TipoEquipo
    {
        public record RegistarTipoEquipo(int Id,string NombreTipoEquipo):IRequest<bool>;

        public record ModificarTipoEquipo(int Id,string NombreTipoEquipo):IRequest<ModificarTipoEquipoResponse>;

        public class ModificarTipoEquipoResponse
        {
            public int Id { get; set; }
            public string NombreTipoEquipo { get; set; }
        }
        public record EliminarTipoEquipoRequest(int Id):IRequest<bool>;
    }
}
