using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebService_PaperMID_Api.DAL;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/TipoUsuario")]
    public class TipoUsuarioController : Controller
    {
        TipoUsuarioDAL _oTipoUsuarioDAL;
        public TipoUsuarioController()
        {
            _oTipoUsuarioDAL = new TipoUsuarioDAL();
        }

        [HttpGet]
        public IEnumerable<TipoUsuarioModel> ListaTipoUsuario()
        {
            return _oTipoUsuarioDAL.TablaTipoUsuario();
        }

        [HttpGet("{IdTipoUsuario}", Name = "ListaTipoUsuario")]
        public IActionResult ObtenerTipoUsuario(long IdTipoUsuario)
        {
            var Repositorio = _oTipoUsuarioDAL.RecuperarTipo(IdTipoUsuario);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
  
        }
    }
}