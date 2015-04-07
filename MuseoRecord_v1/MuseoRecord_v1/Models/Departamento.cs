using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoID { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        [StringLength(32)]
        public string Nombre { get; set; }
        public int Estado { get; set; }

        /*Propiedades de navegacion*/
        public virtual ICollection<Puesto> Puestos { get; set; }

    }
}