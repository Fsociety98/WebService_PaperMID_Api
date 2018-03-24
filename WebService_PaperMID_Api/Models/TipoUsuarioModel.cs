using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class TipoUsuarioModel
    {
        public int IdTipoUsuario { get; set; }
        public string TipoUsu { get; set; }
        public DateTime FechaRegistroTuser { get; set; }
        public Boolean StatusTuser { get; set; }
    }
}
