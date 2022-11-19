using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public partial class EquiposBaja
    {
        [Key]
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Comentario { get; set; }
        public Orden Orden { get; set; }
    }
}
