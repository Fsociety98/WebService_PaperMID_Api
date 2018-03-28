using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class Login_RespuestaModel
    {
        public int IdUsuario { get; set; }
        public string Modulo { get; set; }
        public string NombreUsu { get; set; }
    }
}
