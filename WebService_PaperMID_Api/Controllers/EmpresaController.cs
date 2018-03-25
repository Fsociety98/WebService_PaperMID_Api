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
    [Route("api/Empresa")]
    public class EmpresaController : Controller
    {
        EmpresaDAL _oEmpresaDAL;
        public EmpresaController()
        {
            _oEmpresaDAL = new EmpresaDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<EmpresaModel> ListaDatosEmpresa()
        {
            return _oEmpresaDAL.DatosEmpresa();
        }

        [HttpGet("{IdPapeleria}", Name = "ListaDatosEmpresa")]
        public IActionResult ObtenerDatosEmpresa(long IdPapeleria)
        {
            var Repositorio = _oEmpresaDAL.Obtener_Empresa(IdPapeleria);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdPapeleria}")]
        public IActionResult ModificarProducto(long IdPapeleria, [FromBody] EmpresaModel _oEmpresaModel)
        {
            if (_oEmpresaModel == null || _oEmpresaModel.IdPapeleria != IdPapeleria)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oEmpresaDAL.Obtener_Empresa(1);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oEmpresaDAL.Modificar(_oEmpresaModel);
                return new NoContentResult();
            }
        }
        #endregion
    }
}