﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ContadSp.Modelos;

namespace ContadSp.Modelos
{
    public class Modelo_Articulos
    {
        public Modelo_Articulos()
        {
            fecha_ultimo_monto = DateOnly.FromDateTime(DateTime.Now);
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string descripcion { get; set; }
        public double monto_aprox { get; set; }
        public DateOnly fecha_ultimo_monto { get; set; }
        public string? foto { get; set; }

        [ForeignKey("id_categoria")]
        public int id_categoria { get; set; } 
        public Modelo_ABM_Categoria Categoria { get; set; }

        public List<Modelo_Detalle_Pedido>? Detalle_Pedido { get; set; }
    }
}
