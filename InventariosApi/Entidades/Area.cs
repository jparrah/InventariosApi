using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public partial class Area
    {
        public Area()
        {
            Equipos = new HashSet<Equipos>();
            EquiposDefectados = new HashSet<EquiposDefectados>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre del area no debe ser null")]
        public string NombreArea { get; set; }
        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<EquiposDefectados> EquiposDefectados { get; set; }
    }
}
