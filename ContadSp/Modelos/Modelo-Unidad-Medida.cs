using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSp.Modelos
{
    public class Modelo_Unidad_Medida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? unidad { get; set; }

        public List<Modelo_Detalle_Pedido>? Detalle_Pedido { get; set; }
    }
}
