using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class Lista
    {
        public int ListaID { get; set; }
        public int TipoAtributoID { get; set; }
        public string Valor { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion*/
        public virtual TipoAtributo TipoAtributo { get; set; }
        public virtual ICollection<Atributo> Atributos { get; set; }


    }
}
