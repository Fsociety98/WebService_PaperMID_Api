using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class EgresoModel
    {
        public int IdEgreso { get; set; }
        public int IdProducto { get; set; }
        public int IdTipoEgreso { get; set; }
        public int CantidadEgresada { get; set; }
    }
}
