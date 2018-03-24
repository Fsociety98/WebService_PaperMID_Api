using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class PromocionModel
    {
        public int IdPromocion { get; set; }
        public string NombrePromo { get; set; }
        public string DescripcionPromo { get; set; }
        public string FechaInicioPromo { get; set; }
        public string FechaFinPromo { get; set; }
        public double DescuentoPromo { get; set; }
        public int IdProveedor1 { get; set; }
    }
}
