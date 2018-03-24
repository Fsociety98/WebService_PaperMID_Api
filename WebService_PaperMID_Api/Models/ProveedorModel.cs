using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class ProveedorModel
    {
        public int IdProveedor { get; set; }
        public string NombreProv { get; set; }
        public string TelefonoProv { get; set; }
        public string CorreoProv { get; set; }
        public DateTime FechaRegistroProv { get; set; }
        public bool StatusProv { get; set; }
    }
}
