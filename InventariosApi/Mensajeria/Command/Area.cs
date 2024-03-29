﻿using MediatR;

namespace InventariosApi.Mensajeria.Command
{
    public class Area
    {
        public record RegistrarAreaRequest(string NombreArea) : IRequest<bool>;

        public record ModificarAreaRequest(int Id, string NombreArea) : IRequest<ModificarAreaResponse>;

        public class ModificarAreaResponse
        {
            public int Id { get; set; }
            public string NombreArea { get; set; }
        }
        public record EliminarAreaRequest(int Id) : IRequest<bool>;
    }
}
