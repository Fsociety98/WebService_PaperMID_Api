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
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        MensajeDAL _oUsuarioDAL;
        public UsuarioController()
        {
            _oUsuarioDAL = new MensajeDAL();
        }
        //GET
        #region
        [HttpGet]
        public IEnumerable<UsuarioModel> ListaUsuarios()
        {
            return _oUsuarioDAL.TablaUsuarios();
        }

        [HttpGet("{IdUsuario}", Name = "ListaUsuarios")]
        public IActionResult ObtenerUsuario(long IdUsuario)
        {
            var Repositorio = _oUsuarioDAL.Obtener_Usuario(IdUsuario);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //POST
        #region
        [HttpPost]
        public IActionResult AgregarUsuario([FromBody] UsuarioModel _oUsuarioModel)
        {
            if (_oUsuarioModel == null)
                return BadRequest();
            else
                _oUsuarioDAL.Agregar(_oUsuarioModel);
            return CreatedAtRoute("ListaUsuarios", new { IdUsuario = _oUsuarioModel.IdUsuario }, _oUsuarioModel);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdUsuario}")]
        public IActionResult ModificarProveedor(long IdUsuario, [FromBody] UsuarioModel _oUsuarioModel)
        {
            if (_oUsuarioModel == null || _oUsuarioModel.IdUsuario != IdUsuario)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oUsuarioDAL.Obtener_Usuario(IdUsuario);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oUsuarioDAL.Modificar(_oUsuarioModel);
                return new NoContentResult();
            }
        }
        #endregion

        //DELETE
        #region
        [HttpDelete("{IdUsuario}")]
        public IActionResult EliminarProveedor(long IdUsuario)
        {
            var Busqueda = _oUsuarioDAL.Obtener_Usuario(IdUsuario);
            if (Busqueda == null)
                return NotFound();
            else
                _oUsuarioDAL.Eliminar(IdUsuario);
            return new NoContentResult();
        }
        #endregion
    }
}