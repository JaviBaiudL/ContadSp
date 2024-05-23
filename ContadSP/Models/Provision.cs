using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class Provision
    {
        public Provision()
        {
            fecha_provision = DateOnly.FromDateTime(DateTime.Now);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_provision { get; set; }
        public string? descripcion { get; set; }
        public double total { get; set; }
        public string? total_letra { get; set; }
        public bool estado { get; set; }
        public List<DetalleProvision> DetalleProvision { get; set; }
        public List<Pedido> Pedido { get; set; }

        [ForeignKey("destino_id")]
        public int destino_id { get; set; }
        public Destino Destino { get; set; }

        [ForeignKey("usuario_id")]
        public int usuario_id { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("proceso_id")]
        public int proceso_id { get; set; }
        public Proceso Proceso { get; set; }
    }
}
