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
    [Route("api/Promocion")]
    public class PromocionController : Controller
    {
        PromocionDAL _oPromocionDAL;
        public PromocionController()
        {
            _oPromocionDAL = new PromocionDAL();
        }
        //GET
        #region
        [HttpGet]
        public IEnumerable<PromocionModel> ListaPromociones()
        {
            return _oPromocionDAL.TablaPromociones();
        }

        [HttpGet("{IdPromocion}", Name = "ListaPromociones")]
        public IActionResult ObtenerPromocion(long IdPromocion)
        {
            var Repositorio = _oPromocionDAL.Recuperar_Promo(IdPromocion);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        //POST
        #region
        [HttpPost]
        public IActionResult AgregarPromocion([FromBody] PromocionModel _oPromocionModel)
        {
            if (_oPromocionModel == null)
                return BadRequest();
            else
                _oPromocionDAL.Agregar(_oPromocionModel);
            return CreatedAtRoute("ListaPromociones", new { IdPromocion = _oPromocionModel.IdPromocion }, _oPromocionModel);
        }
        #endregion

        //PUT
        #region
        [HttpPut("{IdPromocion}")]
        public IActionResult ModificarPromocion(long IdPromocion, [FromBody] PromocionModel _oPromocionModel)
        {
            if (_oPromocionModel == null || _oPromocionModel.IdPromocion != IdPromocion)
            {
                return BadRequest();
            }
            else
            {
                var Busqueda = _oPromocionDAL.Recuperar_Promo(IdPromocion);
                if (Busqueda == null)
                    return NotFound();
                else
                    _oPromocionDAL.Modificar(_oPromocionModel);
                return new NoContentResult();
            }
        }
        #endregion

        //DELETE
        #region
        [HttpDelete("{IdPromocion}")]
        public IActionResult EliminarPromocion(long IdPromocion)
        {
            var Busqueda = _oPromocionDAL.Recuperar_Promo(IdPromocion);
            if (Busqueda == null)
                return NotFound();
            else
                _oPromocionDAL.Eliminar(IdPromocion);
            return new NoContentResult();
        }
        #endregion
    }
}