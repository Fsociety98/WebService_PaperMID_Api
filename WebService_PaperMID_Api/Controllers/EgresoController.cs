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
    [Route("api/Egreso")]
    public class EgresoController : Controller
    {
        EgresoDAL _oEgresoDAL;
        public EgresoController()
        {
            _oEgresoDAL = new EgresoDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<Vst_EgresoModel> ListaEgresos()
        {
            return _oEgresoDAL.TablaEgresos();
        }
        #endregion
        //POST
        #region
        [HttpPost]
        public IActionResult AgregarEgreso([FromBody] EgresoModel _oEgresoModel)
        {
            if (_oEgresoModel == null)
                return BadRequest();
            else
                _oEgresoDAL.Agregar(_oEgresoModel);
            return CreatedAtRoute("ListaEgresos", new { IdIngreso = _oEgresoModel.IdEgreso }, _oEgresoModel);
        }
        #endregion


        //DELETE
        #region
        [HttpDelete("{IdEgreso}")]
        public IActionResult EliminarEgreso(long IdEgreso)
        {
            _oEgresoDAL.Eliminar(IdEgreso);
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