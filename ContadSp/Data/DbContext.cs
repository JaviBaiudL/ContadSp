using ContadSp.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ContadSp.Data
{
    public class ContadSpContext : DbContext
    {
        public ContadSpContext(DbContextOptions<ContadSpContext> options)
            : base(options)
        {
        }

        public DbSet<Modelo_ABM_Categoria>? Modelo_ABM_Categoria { get; set; }
        public DbSet<Modelo_Articulos>? Modelo_Articulos { get; set; }
        public DbSet<Modelo_Pedido>? Modelo_Pedidos { get; set; }
        public DbSet<Modelo_Detalle_Pedido>? Modelo_Detalle_Pedido { get; set; }
        public DbSet<Modelo_Unidad_Medida>? Modelo_Unidad_Medida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Modelo_Articulos>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Articulos)
                .HasForeignKey(a => a.id_categoria);

            modelBuilder.Entity<Modelo_Detalle_Pedido>()
                .HasOne(a => a.Articulos)
                .WithMany(d => d.Detalle_Pedido)
                .HasForeignKey(a => a.id_articulo);

            modelBuilder.Entity<Modelo_Detalle_Pedido>()
                .HasOne(p => p.Pedido)
                .WithMany(d => d.Detalle_Pedido)
                .HasForeignKey(p => p.id_pedido);

            modelBuilder.Entity<Modelo_Detalle_Pedido>()
                .HasOne(u => u.Unidad_Medida)
                .WithMany(d => d.Detalle_Pedido)
                .HasForeignKey(u => u.id_unidad);
        }
    }
}
