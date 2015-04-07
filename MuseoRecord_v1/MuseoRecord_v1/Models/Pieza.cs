using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MuseoRecord_v1.Models
{
    public class Pieza
    {
        public int PiezaID { get; set; }
        public int ObraID { get; set; }
        public int TipoPiezaID { get; set; }
        public string Matricula { get; set; }
        public string MatriculaTecnica { get; set; }
        //public int UbicacionID { get; set; }

        /* Propiedades de navegacion*/
        public virtual Obra Obra { get; set; }
        public virtual TipoPieza TipoPieza { get; set; }
        
        // Queda pendientes los movimientos


    }
}
