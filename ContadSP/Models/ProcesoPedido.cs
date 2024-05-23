﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContadSP.Models
{
    public class ProcesoPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int num_proceso { get; set; }
        public string? proceso_completo { get; set; }
        public List<Pedido> Pedido { get; set; }
        [ForeignKey("proceso_id")]
        public int proceso_id { get; set; }
        public Proceso Proceso { get; set; }
    }
}
