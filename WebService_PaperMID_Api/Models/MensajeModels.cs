using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class MensajeModels
    {
        public int IdMensaje { get; set; }
        public string Mensaje { get; set; }
        public string Nombre { get; set; }
        public int Usuario { get; set; }
        public string Asunto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estatus { get; set; }
    }
}
