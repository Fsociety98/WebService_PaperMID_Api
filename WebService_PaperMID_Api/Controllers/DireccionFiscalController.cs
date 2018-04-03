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
    [Route("api/DireccionFiscal")]
    public class DireccionFiscalController : Controller
    {
        DireccionFiscalDAL _oDireccionFiscalDAL;
        public DireccionFiscalController()
        {
            _oDireccionFiscalDAL = new DireccionFiscalDAL();
        }


        //GET
        #region
        [HttpGet]
        public IEnumerable<DireccionFiscalModel> ListaDireccionesFiscales()
        {
            return _oDireccionFiscalDAL.TablasDireccionesFiscales();
        }

        [HttpGet("{IdDireccionFiscal}", Name = "ListaDireccionesFiscales")]
        public IActionResult ObtenerDireccionFiscal(long IdDireccionFiscal)
        {
            var Repositorio = _oDireccionFiscalDAL.Recuperar_DirFis(IdDireccionFiscal);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //POST
        #region
        [HttpPost]
        public IActionResult AgregarDireccionFiscal([FromBody] DireccionFiscalModel _oDireccionFiscalModel)
        {
            if (_oDireccionFiscalModel == null)
                return BadRequest();
            else
                _oDireccionFiscalDAL.Agregar(_oDireccionFiscalModel);
            return CreatedAtRoute("ListaDireccionesFiscales", new { IdDireccionFiscal = _oDireccionFiscalModel.IdDireccionFiscal }, _oDireccionFiscalModel);
        }
        #endregion
    }
}