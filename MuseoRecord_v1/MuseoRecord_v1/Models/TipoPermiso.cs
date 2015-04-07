using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class TipoPermiso
    {
        [Key]
        public int TipoPermisoID { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Estado { get; set; }
        
        /*Propiedades de navegacion*/
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}