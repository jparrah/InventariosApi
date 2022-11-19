using System.ComponentModel.DataAnnotations;

namespace InventariosApi.Entidades
{
    public partial class Equipos
    {
        public Equipos()
        {
            Componentes = new HashSet<Componente>();
        }
        [Key]
        public int Id { get; set; }
        public int EstadoId { get; set; }
        public int AreaId { get; set; }
        public int TipoEquipoId { get; set; }
        public int SucursalId { get; set; }
        public long Inventario { get; set; }
        public float Valor { get; set; }
        public float Depreciacion { get; set; }
        public long Sello { get; set; }

        public Estado Estado { get; set; }
        public Area Area { get; set; }
        public TipoEquipo Medios { get; set; }
        public Sucursal Sucursal { get; set; }
        public Orden Orden { get; set; }
        public virtual ICollection<Componente> Componentes { get; set; }




    }
}
