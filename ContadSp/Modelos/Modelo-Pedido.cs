using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSp.Modelos
{
    public class Modelo_Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fecha_pedido { get; set; }
        public string? destino { get; set; }
        public string? descripcion { get; set; }
        public string? usuario_solicita { get; set; }
        public List<Modelo_Articulos>? Articulos { get; set; }

    }
}
