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
    [Route("api/Proveedor")]
    public class ProveedorController : Controller
    {
        ProveedorDAL _oProveedorDAL;
        public ProveedorController()
        {
            _oProveedorDAL = new ProveedorDAL();
        }
        //GET
        #region
        [HttpGet]
        public IEnumerable<ProveedorModel> ListaProveedores()
        {
            return _oProveedorDAL.TablaProveedores();
        }

        [HttpGet("{IdProveedor}", Name = "ListaProveedores")]
        public IActionResult ObtenerProveedor(long IdProveedor)
        {
            var Repositorio = _oProveedorDAL.Recuperar_Proveedor(IdProveedor);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //POST
        #region
        [HttpPost]
        public IActionResult AgregarProveedor([FromBody] ProveedorModel _oProveedorModel)
        {
            if (_oProveedorModel==null)
                return BadRequest();
            else
                _oProveedorDAL.Agregar(_oProveedorModel);
                return CreatedAtRoute("ListaProveedores", new { IdProveedor = _oProveedorModel.IdProveedor }, _oProveedorModel);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdProveedor}")]
        public IActionResult ModificarProveedor(long IdProveedor,[FromBody] ProveedorModel _oProveedorModel)
        {
            if (_oProveedorModel==null||_oProveedorModel.IdProveedor!=IdProveedor)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oProveedorDAL.Recuperar_Proveedor(IdProveedor);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oProveedorDAL.Modificar(_oProveedorModel);
                    return new NoContentResult();
            } 
        }
        #endregion

        //DELETE
        #region
        [HttpDelete("{IdProveedor}")]
        public IActionResult EliminarProveedor(long IdProveedor)
        {
            var Busqueda = _oProveedorDAL.Recuperar_Proveedor(IdProveedor);
            if (Busqueda == null)
                return NotFound();
            else
                _oProveedorDAL.Eliminar(IdProveedor);
                return new NoContentResult();
        }
        #endregion
    }
}