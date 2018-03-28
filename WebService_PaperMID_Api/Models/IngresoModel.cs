using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class IngresoModel
    {
        public int IdIngreso { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoIngreso { get; set; }
        public int CantidadIngresada { get; set; }
    }
}
