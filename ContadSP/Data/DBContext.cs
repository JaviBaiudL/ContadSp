using ContadSP.Models;
using Microsoft.EntityFrameworkCore;

namespace ContadSP.Data
{
    public class ContadSPContext : DbContext
    {
        public ContadSPContext(DbContextOptions<ContadSPContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Destino> Destino { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<DetalleProvision> DetalleProvision { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Proceso> Proceso { get; set; }
        public DbSet<ProcesoPedido> ProcesoPedido { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Provision> Provision { get; set; }
        public DbSet<SitFiscal> SitFiscal { get; set; }
        public DbSet<TipoPedido> TipoPedido { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relaciones de Articulo con Categoria
            modelBuilder.Entity<Articulo>()
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Articulo)
                .HasForeignKey(a => a.categoria_id);
            // Relaciones de Provision con Destino, Proceso y Usuario
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Destino)
                .WithMany(d => d.Provision)
                .HasForeignKey(p => p.destino_id);
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Provision)
                .HasForeignKey(p => p.usuario_id);
            modelBuilder.Entity<Provision>()
                .HasOne(p => p.Proceso)
                .WithMany(pr => pr.Provision)
                .HasForeignKey(p => p.proceso_id);
            // Relaciones de DetallePedido con Articulo, Pedido y UnidadMedida
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Articulo)
                .WithMany(a => a.DetallePedido)
                .HasForeignKey(d => d.articulo_id);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Pedido)
                .WithMany(p => p.DetallePedido)
                .HasForeignKey(d => d.pedido_id);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.UnidadMedida)
                .WithMany(u => u.DetallePedido)
                .HasForeignKey(d => d.unidad_id);
            // Relaciones de Proceso con TipoPedido
            modelBuilder.Entity<Proceso>()
                .HasOne(p => p.TipoPedido)
                .WithMany(t => t.Proceso)
                .HasForeignKey(p => p.tipo_pedido_id);
            // Relaciones de DetalleProvision con Articulo, Proceso y UnidadMedida y Provision
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.Articulo)
                .WithMany(a => a.DetalleProvision)
                .HasForeignKey(d => d.articulo_id);
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.UnidadMedida)
                .WithMany(u => u.DetalleProvision)
                .HasForeignKey(d => d.unidad_id);
            modelBuilder.Entity<DetalleProvision>()
                .HasOne(d => d.Provision)
                .WithMany(p => p.DetalleProvision)
                .HasForeignKey(d => d.provision_id);
            // Relacion de Proveedor con SitFiscal
            modelBuilder.Entity<Proveedor>()
                .HasOne(s => s.SitFiscal)
                .WithMany(p => p.Proveedor)
                .HasForeignKey(s => s.sit_fiscal_id);
            // Relacion de Pedido con Provision y ProcesoPedido
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Provision)
                .WithMany(pv => pv.Pedido)
                .HasForeignKey(p => p.provision_id);
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.ProcesoPedido)
                .WithMany(pp => pp.Pedido)
                .HasForeignKey(p => p.proceso_pedido_id);
            // Relacion de ProcesoPedido con Proceso
            modelBuilder.Entity<ProcesoPedido>()
                .HasOne(pp => pp.Proceso)
                .WithMany(p => p.ProcesoPedido)
                .HasForeignKey(pp => pp.proceso_id);
        }
    }
}
