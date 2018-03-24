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
    [Route("api/Producto")]
    public class ProductoController : Controller
    {
        ProductoDAL _oProductoDAL;
        public ProductoController()
        {
            _oProductoDAL = new ProductoDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<ProductoModel> ListaProductos()
        {
            return _oProductoDAL.Lista_Producto();
        }

        [HttpGet("{IdProducto}", Name = "ListaProductos")]
        public IActionResult ObtenerProducto(long IdProducto)
        {
            var Repositorio = _oProductoDAL.RecuperarProducto(IdProducto);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion


        //POST
        #region
        [HttpPost]
        public IActionResult AgregarProducto([FromBody] ProductoModel _oProductoModel)
        {
            if (_oProductoModel == null)
                return BadRequest();
            else
                _oProductoDAL.Agregar(_oProductoModel);
            return CreatedAtRoute("ListaProductos", new { IdProducto = _oProductoModel.IdProducto }, _oProductoModel);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdProducto}")]
        public IActionResult ModificarProducto(long IdProducto, [FromBody] ProductoModel _oProductoModel)
        {
            if (_oProductoModel == null || _oProductoModel.IdProducto != IdProducto)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oProductoDAL.RecuperarProducto(IdProducto);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oProductoDAL.Modificar(_oProductoModel);
                return new NoContentResult();
            }
        }
        #endregion

        //DELETE
        #region
        [HttpDelete("{IdProducto}")]
        public IActionResult EliminarProducto(long IdProducto)
        {
            var Busqueda = _oProductoDAL.RecuperarProducto(IdProducto);
            if (Busqueda == null)
                return NotFound();
            else
                _oProductoDAL.Eliminar(IdProducto);
            return new NoContentResult();
        }
        #endregion
    }
}