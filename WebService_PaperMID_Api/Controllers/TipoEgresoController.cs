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
    [Route("api/TipoEgreso")]
    public class TipoEgresoController : Controller
    {
        TipoEgresoDAL _oTipoEgresoDAL;
        public TipoEgresoController()
        {
            _oTipoEgresoDAL = new TipoEgresoDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<TipoEgresoModel> ListaTipoEgreso()
        {
            return _oTipoEgresoDAL.TablaTipoEgreso();
        }
        #endregion
    }
}