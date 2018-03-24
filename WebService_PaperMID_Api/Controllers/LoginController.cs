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
    [Route("api/Login")]
    public class LoginController : Controller
    {
        LoginDAL _oLoginDAL;
        public LoginController()
        {
            _oLoginDAL = new LoginDAL();
        }
        

        [HttpPost]
        public IActionResult Comprobacion([FromBody] Login_ComprobacionModel _oLogin_ComprobacionModel)
        {
            if (_oLogin_ComprobacionModel == null)
            {
                return BadRequest();
            }
            else
            {
                var Repositorio = _oLoginDAL.Comprobar_Usuario(_oLogin_ComprobacionModel);
                if (Repositorio == null)
                    return NotFound();
                else
                    return new ObjectResult(Repositorio);
            }
        }
    }
}