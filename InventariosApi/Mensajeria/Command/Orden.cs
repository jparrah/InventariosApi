using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Orden
    {
        public record RegistrarOrdenRequest(
                                    int Id,
                                    int EquiposId,
                                    int TecnicoId,
                                    int SucursalId,
                                    DateTime FechaEntrada,
                                    string Fundamento):IRequest<bool>;
        public record ModificarOrdenRequest(
                                    int Id,
                                    int EquiposId,
                                    int TecnicoId,
                                    int SucursalId,
                                    DateTime FechaEntrada,
                                    string Fundamento):IRequest<ModificarOrdenResponse>;

        public class ModificarOrdenResponse
        {
         public  int Id { get; set; }
         public  int EquiposId { get; set; }
         public  int TecnicoId { get; set; }
         public  int SucursalId { get; set; }
         public  DateTime FechaEntrada { get; set; }
         public  string Fundamento { get; set; }

        }
        public record EliminarOrdenRequest(int Id):IRequest<bool>;

       
    }
}
