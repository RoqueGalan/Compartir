using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class Puesto
    {
        [Key]
        public int PuestoID { get; set; }

        [Required]
        [Display(Name = "Puesto")]
        [StringLength(32)]
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public int DepartamentoID { get; set; }

        /*Propiedades de navegacion*/
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}