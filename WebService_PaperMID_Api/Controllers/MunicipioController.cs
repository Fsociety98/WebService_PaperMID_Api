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
    [Route("api/Municipio")]
    public class MunicipioController : Controller
    {
        MunicipioDAL _oMunicipioDAL;
        public MunicipioController()
        {
            _oMunicipioDAL = new MunicipioDAL();
        }
        #region
        [HttpGet]
        public IEnumerable<MunicipioModel> ListaMunicipios()
        {
            return _oMunicipioDAL.TablaMunicipios();
        }

        [HttpGet("{IdMunicipio}", Name = "ListaMunicipios")]
        public IActionResult ObtenerMunicipio(long IdMunicipio)
        {
            var Repositorio = _oMunicipioDAL.Recuperar_Muni(IdMunicipio);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion
    }
}