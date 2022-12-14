using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public class EquiposDefectados
    {
        public EquiposDefectados()
        {
            Componentes=new HashSet<Componente>();
            Labores = new HashSet<Labores>();
        }
        [Key]
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public int AreaId { get; set; }
        public int TipoEquipoId { get; set; }
        public int SucursalId { get; set; }
        public long Inventario { get; set; }
        public int DefectacionId { get; set; }
        public string Sello { get; set; }
        public DateTime FechaReparada { get; set; }
        public DateTime FechaSalida { get; set; }
        public Defectacion Defectacion { get; set; }
        public Estado Estado { get; set; }
        public Area Area { get; set; }
        public TipoEquipo Medios { get; set; }
        public Sucursal Sucursal { get; set; }
        public Orden Orden { get; set; }
        public EquiposBaja EquiposBaja { get; set; }
        public virtual ICollection<Componente> Componentes { get; set; }
        public virtual ICollection<Labores> Labores { get; set; }
    }
}
