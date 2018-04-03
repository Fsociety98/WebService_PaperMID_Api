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
    [Route("api/TipoIngreso")]
    public class TipoIngresoController : Controller
    {
        TipoIngresoDAL _oTipoIngresoDAL;
        public TipoIngresoController()
        {
            _oTipoIngresoDAL = new TipoIngresoDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<TipoIngresoModel> ListaTipoIngreso()
        {
            return _oTipoIngresoDAL.TablaTipoIngreso();
        }
        #endregion
    }
}