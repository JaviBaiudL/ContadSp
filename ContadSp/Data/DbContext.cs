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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Modelo_Articulos>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Articulos)
                .HasForeignKey(a => a.id_categoria);
        }
    }
    

}
