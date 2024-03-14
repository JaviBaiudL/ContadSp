using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSp.Modelos
{
    public class Modelo_Pedido
    {
        public Modelo_Pedido()
        {
            fecha_pedido = DateOnly.FromDateTime(DateTime.Now);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_pedido { get; set; }
        public string? descripcion { get; set; }
        public string? usuario_solicita { get; set; }

        public List<Modelo_Detalle_Pedido>? Detalle_Pedido { get; set; }

        [ForeignKey("id_destino")]
        public int id_destino { get; set; }
        public Modelo_Destino Destino { get; set; }
    } 
}
