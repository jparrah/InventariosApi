using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Tecnico
    {
        public record RegistrarTecnicoRequest(
                        long CI,
                        string Nombre,
                        string PrimerApellido,
                        string SegundoApellido):IRequest<bool>;

        public record ModificarTecnicoRequest(
                        int Id,
                        long CI,
                        string Nombre,
                        string PrimerApellido,
                        string SegundoApellido):IRequest<ModificarTecnicoResponse>;
        public class ModificarTecnicoResponse
        {
            public int Id { get; set; }
            public long CI { get; set; }
            public string Nombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
        }

        public record EliminarTecnicoRequest(int Id):IRequest<bool>;
    }
}
