using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public  class Sucursal
    {
        public Sucursal()
        {
            Equipos = [];
            EquiposDefectados= new HashSet<EquiposDefectados>();
            Ordenes = new HashSet<Orden>();
        }
        [Key]
        public int Id { get; set; }
        public int CodigoSucursal { get; set; }
        public string NombreSucursal { get; set; }

        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<EquiposDefectados> EquiposDefectados { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
