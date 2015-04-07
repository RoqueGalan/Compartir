using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class TipoAtributo
    {
        public int TipoAtributoID { get; set; }
        public string Nombre { get; set; }
        public bool EsLista { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion*/
        public virtual ICollection<Lista> Lista { get; set; }
        public virtual ICollection<Estructura> Estructuras { get; set; }

    }
}
