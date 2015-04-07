using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        
        [Required ]
        [Display(Name = "Nombre(s)")]
        [StringLength(32)]
        public string Nombre { get; set; }
        
        [Required]
        [Display(Name = "Apellido(s)")]
        [StringLength(32)]
        public string Apellido { get; set; }
        
        [Required]
        [Display(Name = "Correo Eléctronico")]
        [EmailAddress]
        [StringLength(64)]
        public string Correo { get; set; }
        
        [Required]
        [Display(Name = "Contraseña")]
        [MinLength(4)]
        public string Contrasena { get; set; }
        public int Estado { get; set; }
        public int PuestoID { get; set; }

        /*Propiedades de navegacion*/
        public virtual Puesto Puesto { get; set; }




    }
}