using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class Propietario
    {
        public int PropietarioID { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion*/
        public virtual ICollection<Obra> Obras { get; set; }

    }
}
