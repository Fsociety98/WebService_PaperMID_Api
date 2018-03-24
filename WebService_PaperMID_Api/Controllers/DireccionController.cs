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
    [Route("api/Direccion")]
    public class DireccionController : Controller
    {
        DireccionDAL _oDireccionDAL;
        public DireccionController()
        {
            _oDireccionDAL = new DireccionDAL();
        }
        //GET
        #region
        [HttpGet]
        public IEnumerable<DireccionModel> ListaDirecciones()
        {
            return _oDireccionDAL.TablaDirecciones();
        }

        [HttpGet("{IdDireccion}", Name = "ListaDirecciones")]
        public IActionResult ObtenerDireccion(long IdDireccion)
        {
            var Repositorio = _oDireccionDAL.Obtener_Direccion(IdDireccion);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //POST
        #region
        [HttpPost]
        public IActionResult AgregarDireccion([FromBody] DireccionModel _oDireccionModel)
        {
            if (_oDireccionModel == null)
                return BadRequest();
            else
                _oDireccionDAL.Agregar(_oDireccionModel);
            return CreatedAtRoute("ListaDirecciones", new { IdProveedor = _oDireccionModel.IdDireccion }, _oDireccionModel);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdDireccion}")]
        public IActionResult ModificarDireccion(long IdDireccion, [FromBody] DireccionModel _oDireccionModel)
        {
            if (_oDireccionModel == null || _oDireccionModel.IdDireccion != IdDireccion)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oDireccionDAL.Obtener_Direccion(IdDireccion);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oDireccionDAL.Modificar(_oDireccionModel);
                return new NoContentResult();
            }
        }
        #endregion

        //DELETE
        #region
        [HttpDelete("{IdDireccion}")]
        public IActionResult EliminarDireccion(long IdDireccion)
        {
            var Busqueda = _oDireccionDAL.Obtener_Direccion(IdDireccion);
            if (Busqueda == null)
                return NotFound();
            else
                _oDireccionDAL.Eliminar(IdDireccion);
            return new NoContentResult();
        }
        #endregion
    }
}