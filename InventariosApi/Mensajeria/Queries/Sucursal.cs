using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Sucursal
    {
        public record ListarSucursalesRequest():IRequest<IEnumerable<ListarSucursalesResponse>>;

        public class ListarSucursalesResponse
        {
            public int Id { get; set; }
            public int CodigoSucursal { get; set; }

            public string NombreSucursal { get; set; }
        }

        public record ObtenerSucursalRequest(int Id):IRequest<ObtenerSucursalResponse>;

        public class ObtenerSucursalResponse
        {
            public int Id { get; set; }
            public int CodigoSucursal { get; set; }

            public string NombreSucursal { get; set; }
        }
    }
}
