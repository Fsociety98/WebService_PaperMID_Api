using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class Vst_EgresoModel
    {
        public int IdEgreso { get; set; }
        public string CódigoProd { get; set; }
        public string NombreProd { get; set; }
        public int CantidadEgresada { get; set; }
        public string TipoEgreso { get; set; }
    }
}
