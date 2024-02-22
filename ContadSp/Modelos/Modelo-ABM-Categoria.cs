using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ContadSp.Modelos;

namespace ContadSp.Modelos
{
    public class Modelo_ABM_Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? categoria { get; set; }
        public List<Modelo_Articulos>? Articulos { get; set; } // Reference to child articles
    }
}
