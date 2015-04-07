using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MuseoRecord_v1.Models
{
    public class Obra
    {
        public int ObraID { get; set; }
        public string Titulo { get; set; }
        public string Matricula { get; set; }
        public string MatriculaTecnica { get; set; }
        public int TipoAdquisicionID { get; set; }
        public int PropietarioID { get; set; }
        public int TipoObraID { get; set; }
        public bool Comodato { get; set; }
        public int Estado { get; set; }

        /* Propiedades de navegacion */
        public virtual TipoAdquisicion TipoAdquision { get; set; }
        public virtual Propietario  Propietario { get; set; }
        public virtual TipoObra TipoObra { get; set; }
        public virtual ICollection<Pieza> Piezas { get; set; }

    }
}