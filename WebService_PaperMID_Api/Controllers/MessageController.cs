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
    [Route("api/Message")]
    public class MessageController : Controller
    {
        MessageDAL _oMensajeDAL;
        public MessageController()
        {
            _oMensajeDAL = new MessageDAL ();
        }
        //GET
        #region
        [HttpGet]
        public IEnumerable<MensajeModels> ListaMensajes ()
        {
            return _oMensajeDAL.TablaMensajes();
        }

        [HttpGet("{IdMensaje}", Name = "ListaMensajes")]
        public IActionResult ObtenerMensaje(long IdMensaje)
        {
            var Repositorio = _oMensajeDAL.Recuperar_Mensa(IdMensaje);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion
        //POST
        #region
        [HttpPost]
        public IActionResult AgregarMensaje([FromBody] MensajeModels _oMensajeModels)
        {
            if (_oMensajeModels == null)
                return BadRequest();
            else
                _oMensajeDAL.AgregarPublico(_oMensajeModels);
            return CreatedAtRoute("ListaMensajes", new { IdPromocion = _oMensajeModels.IdMensaje }, _oMensajeModels);
        }
        #endregion
           }
}