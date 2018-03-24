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
    [Route("api/TipoProducto")]
    public class TipoProductoController : Controller
    {
        TipoProductoDAL _oTipoProductoDAL;
        public TipoProductoController()
        {
            _oTipoProductoDAL = new TipoProductoDAL();
        }

        [HttpGet]
        public IEnumerable<TipoProductoModel> ListaTipoProducto()
        {
            return _oTipoProductoDAL.TabTipoProd();
        }

        [HttpGet("{IdTipoProducto}", Name = "ListaTipoProducto")]
        public IActionResult ObtenerTipoProducto(long IdTipoProducto)
        {
            var Repositorio = _oTipoProductoDAL.RecuperarTipo(IdTipoProducto);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        [HttpPost]
        public IActionResult AgregarTipoProducto([FromBody] TipoProductoModel _oTipoProductoModel)
        {
            if (_oTipoProductoModel == null)
                return BadRequest();
            else
                _oTipoProductoDAL.Agregar(_oTipoProductoModel);
            return CreatedAtRoute("ListaTipoProducto", new { IdTipoProducto = _oTipoProductoModel.IdTipoProducto }, _oTipoProductoModel);
        }

        [HttpPut("{IdTipoProducto}")]
        public IActionResult ModificarTipoProducto(long IdTipoProducto, [FromBody] TipoProductoModel _oTipoProductoModel)
        {
            if (_oTipoProductoModel == null || _oTipoProductoModel.IdTipoProducto != IdTipoProducto)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oTipoProductoDAL.RecuperarTipo(IdTipoProducto);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oTipoProductoDAL.Modificar(_oTipoProductoModel);
                return new NoContentResult();
            }
        }

        [HttpDelete("{IdTipoProducto}")]
        public IActionResult EliminarProveedor(long IdTipoProducto)
        {
            var Busqueda = _oTipoProductoDAL.RecuperarTipo(IdTipoProducto);
            if (Busqueda == null)
                return NotFound();
            else
                _oTipoProductoDAL.Eliminar(IdTipoProducto);
            return new NoContentResult();
        }
    }
}