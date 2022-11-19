using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public class EquiposDefectados : Equipos
    {
        public EquiposDefectados()
        {
            Labores = new HashSet<Labores>();
        }
        [Key]
        public int Id { get; set; }
        public int DefectacionId { get; set; }
        public DateTime FechaReparada { get; set; }
        public DateTime FechaSalida { get; set; }
        public long Sello { get; set; }
        public Defectacion Defectacion { get; set; }
        public virtual ICollection<Labores> Labores { get; set; }
    }
}
