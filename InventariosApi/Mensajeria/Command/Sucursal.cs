using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Sucursal
    {
        public record RegistarSucursalRequest(int Id,int CodigoSucursal,string NombreSucursal):IRequest<bool>;

        public record ModificarSucursalRequest(int Id,int CodigoSucursal,string NombreSucursal):IRequest<ModificarSucursalResponse>;

        public class ModificarSucursalResponse
        {
            public int Id { get; set; }
            public int CodigoSucursal { get; set; }
            public string NombreSucursal { get; set; }
        }

        public record EliminarSucursalRequest(int Id):IRequest<bool>;
    }
}
