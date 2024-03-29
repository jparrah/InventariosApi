﻿using MediatR;

namespace InventariosApi.Mensajeria.Queries
{
    public class Orden
    {
        public record ListarOrdenRequest():IRequest<IEnumerable<ListarOrdenResponse>>;
        public record ListarOrdenFechaTecnicoEstadoRequest(DateTime fechaInicial,
                                                            DateTime fechaFinal,
                                                            int tecnicoId,
                                                            string estado):IRequest<IEnumerable<ListarOrdenResponse>>;

        public record ListarOrdenFechaInventarioEstadoRequest(DateTime fechaInicial,
                                                            DateTime fechaFinal,
                                                            long inventario,
                                                            string estado) : IRequest<IEnumerable<ListarOrdenResponse>>;

        public class ListarOrdenResponse
        {
            public int Id { get; set; }
            public string  NombreEquipo { get; set; }
            public string NombreTecnico { get; set; }
            public string NombreSucursal { get; set; }
            public DateTime FechaEntrada { get; set; }
            public string Fundamento { get; set; }
        }
        public record ObtenerOrdenRequest(int Id):IRequest<ObtenerOrdenResponse>;

        public class ObtenerOrdenResponse
        {
            public int Id { get; set; }
            public string NombreEquipo { get; set; }
            public string NombreTecnico { get; set; }
            public string NombreSucursal { get; set; }
            public DateTime FechaEntrada { get; set; }
            public string Fundamento { get; set; }
        }
    }
}
