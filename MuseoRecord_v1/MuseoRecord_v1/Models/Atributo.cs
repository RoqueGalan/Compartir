using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class Atributo
    {
        [Key]
        [Column(Order = 1)]
        public int PiezaID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int EstructuraID { get; set; }
        public string Valor { get; set; }
        public int? ListaID { get; set; }

        /* Propiedades de navegacion*/
        public virtual Pieza Pieza { get; set; }
        public virtual Estructura Estructura { get; set; }
        public virtual Lista Lista { get; set; }

        /* Propiedades Compuestas*/
        //public string ValorReal
        //{
        //    get
        //    {
        //        if (Valor == null)
        //        {
        //            return Lista.Valor;
        //        }
        //        else
        //        {
        //            return Valor;
        //        }

        //    }
        //}
    }
}
