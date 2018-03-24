using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class TipoProductoModel
    {
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public DateTime Fecha_Reg { get; set; }
        public Boolean Status { get; set; }
    }
}
