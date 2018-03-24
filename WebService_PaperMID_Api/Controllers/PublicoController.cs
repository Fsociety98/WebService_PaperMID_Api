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
    [Route("api/Publico")]
    public class PublicoController : Controller
    {
        ProductoDAL _oProductoDAL;
        public PublicoController()
        {
            _oProductoDAL = new ProductoDAL();
        }

        //GET
        #region
 
        [HttpGet]
        public IEnumerable<ProductoModel> Top4()
        {
            return _oProductoDAL.Top4();
        }
        #endregion
    }
}