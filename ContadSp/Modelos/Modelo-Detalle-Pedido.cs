using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSp.Modelos
{
    public class Modelo_Detalle_Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double precio { get; set; }
        public string? precio_letra { get; set; }
        public int cantidad { get; set; }
        public double subtotal { get; set; }
        public string? subtotal_letra { get; set; }

        [ForeignKey("id_articulo")]
        public int id_articulo { get; set; }
        public Modelo_Articulos Articulos { get; set; }

        [ForeignKey("id_pedido")]
        public int id_pedido { get; set; }
        public Modelo_Pedido Pedido { get; set; }

        [ForeignKey("id_unidad")]
        public int id_unidad { get; set; }
        public Modelo_Unidad_Medida Unidad_Medida { get; set; }
    }
}
