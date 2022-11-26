using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Labores
    {
        public record RegistrarLaborRequest(int Id,string NombreLabor):IRequest<bool>;
        public record ModificarLaborRequest(int Id,string NombreLabor):IRequest<ModificarLaborResponse>;

        public class ModificarLaborResponse
        {
            public int Id { get; set; }
            public string NombreLabor { get; set; }
        }
        public record EliminarLaborRequest(int Id):IRequest<bool>;
    }
}
