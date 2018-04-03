using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class DireccionFiscalModel
    {
        public int IdDireccionFiscal { get; set; }
        public string CalleDirFis { get; set; }
        public string NumInteDirFis { get; set; }
        public string NumExteDirFis { get; set; }
        public string CruzaDirFis { get; set; }
        public string ColoniaDirFis { get; set; }
        public string CPDirFis { get; set; }
        public string UbicacionDirFis { get; set; }
        public string LatitudDirFis { get; set; }
        public string LongitudDirFis { get; set; }
        public int IdMunicipio4 { get; set; }
        public string CompletoDirFis { get; set; }
    }
}
