using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class Estructura
    {
        public int EstructuraID { get; set; }
        public int TipoPiezaID { get; set; }
        public int TipoAtributoID { get; set; }
        public int Orden { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion*/
        public virtual TipoPieza TipoPieza { get; set; }
        public virtual TipoAtributo TipoAtributo { get; set; }
        public virtual ICollection<Atributo> Atributos { get; set; }

    }
}
