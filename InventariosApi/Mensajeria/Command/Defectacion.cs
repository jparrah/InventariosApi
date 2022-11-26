using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Defectacion
    {
        public record RegistarDefectacionRequest(int Id,string NombreDefectacion):IRequest<bool>;
        public record ModificarDefectacionRequest(int Id, string NombreDefectacion):IRequest<ModificarDefectacionResponse>;

        public class ModificarDefectacionResponse
        {
            public int Id { get; set; }
            public string NombreDefectacion { get; set; }
        }
        public record EliminarDefectacionRequest(int Id):IRequest<bool>;
    }
}
