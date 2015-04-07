using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class Permiso
    {
        [Key]
        [Column(Order=1)]
        public int PuestoID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int TipoPermisoID { get; set; }

        /* Propiedades de navegacion*/
        public virtual Puesto Puesto { get; set; }
        public virtual TipoPermiso TipoPermiso { get; set; }
    }
}