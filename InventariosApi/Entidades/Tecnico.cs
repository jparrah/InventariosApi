using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public partial class Tecnico
    {
        public Tecnico()
        {
            Ordenes = new HashSet<Orden>();
        }
        [Key]
        public int Id { get; set; }
        public long CI { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public virtual ICollection<Orden> Ordenes { get; set; }
    }
}
