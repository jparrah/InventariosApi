using InventariosApi.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace InventariosApi
{
    public partial class InventariosDbContext : DbContext
    {

        public InventariosDbContext(DbContextOptions<InventariosDbContext> options) : base(options)
        {

        }
       


        
        public virtual DbSet<Area> Area { get; set; } = null!;
        public virtual DbSet<Componente> Componentes { get; set; } = null!;
        public virtual DbSet<Defectacion> Defectaciones { get; set; } = null!;
        public virtual DbSet<EquiposDefectados> EquiposDefectados { get; set; } = null!;
        public virtual DbSet<Equipos> Equipos { get; set; } = null!;
        public virtual DbSet<EquiposBaja> EquiposBajas { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Labores> Labores { get; set; } = null!;
        public virtual DbSet<Orden> Ordenes { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursales { get; set; } = null!;
        public virtual DbSet<Tecnico> Tecnicos { get; set; } = null!;
        public virtual DbSet<TipoEquipo> TipoEquipos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

    }
}
