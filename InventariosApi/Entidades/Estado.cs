using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public partial class Estado
    {
        public Estado()
        {
            Equipos = new HashSet<Equipos>();
        }
        [Key]
        public int Id { get; set; }
        public string NombreEstado { get; set; }
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
