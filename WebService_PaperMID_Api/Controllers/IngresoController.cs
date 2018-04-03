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
    [Route("api/Ingreso")]
    public class IngresoController : Controller
    {
        IngresoDAL _oIngresoDAL;
        public IngresoController()
        {
            _oIngresoDAL = new IngresoDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<Vst_IngresoModel> ListaIngresos()
        {
            return _oIngresoDAL.TablaIngresos();
        }
        #endregion
        //POST
        #region
        [HttpPost]
        public IActionResult AgregarIngreso([FromBody] IngresoModel _oIngresoModel)
        {
            if (_oIngresoModel == null)
                return BadRequest();
            else
                _oIngresoDAL.Agregar(_oIngresoModel);
            return CreatedAtRoute("ListaIngresos", new { IdIngreso = _oIngresoModel.IdIngreso }, _oIngresoModel);
        }
        #endregion


        //DELETE
        #region
        [HttpDelete("{IdIngreso}")]
        public IActionResult EliminarIngreso(long IdIngreso)
        {
            _oIngresoDAL.Eliminar(IdIngreso);
            return new NoContentResult();
            //var Busqueda = _oIngresoDAL.Recuperar_Ingreso(IdIngreso);
            //if (Busqueda == null)
            //    return NotFound();
            //else
            //    _oIngresoDAL.Eliminar(IdIngreso);
            //return new NoContentResult();
        }
        #endregion
    }
}