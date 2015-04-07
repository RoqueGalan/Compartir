using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class TipoPieza
    {
        public int TipoPiezaID { get; set; }
        public int TipoObraID { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion*/
        public virtual TipoObra TipoObra { get; set; }
        public virtual ICollection<Pieza> Piezas { get; set; }
        public virtual ICollection<Estructura> Estructuras { get; set; }
    }
}
