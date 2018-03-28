using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class Vst_IngresoModel
    {
        public int IdIngreso { get; set; }
        public string CódigoProd { get; set; }
        public string NombreProd { get; set; }
        public int CantidadIngresada { get; set; }
        public string TipoIngreso { get; set; }
    }
}
