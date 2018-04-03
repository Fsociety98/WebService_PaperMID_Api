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
    [Route("api/UsuarioCliente")]
    public class UsuarioClienteController : Controller
    {
        UsuarioClienteDAL _oUsuarioClienteDAL;
        public UsuarioClienteController()
        {
            _oUsuarioClienteDAL = new UsuarioClienteDAL();
        }

        //GET
        #region
        [HttpGet]
        public IEnumerable<UsuarioClienteModel> ListaUsuarioCliente()
        {
            return _oUsuarioClienteDAL.TablaDatosUsuario();
        }

        [HttpGet("{Idusuario}", Name = "ListaUsuarioCliente")]
        public IActionResult ObtenerUsuarioCliente(long IdUsuario)
        {
            var Repositorio = _oUsuarioClienteDAL.Recuperar_UsuarioCliente(IdUsuario);
            if (Repositorio == null)
                return NotFound();
            else
                return new ObjectResult(Repositorio);
        }
        #endregion

        [HttpPost]
        public IActionResult BuscarUsuario([FromBody] UsuarioClienteModel _UsuarioClienteModel)
        {
            if (_UsuarioClienteModel == null)
            {
                return BadRequest();
            }
            else
            {
                var Repositorio = _oUsuarioClienteDAL.TablaDatosUsuarioPost(_UsuarioClienteModel.IdUsuario.ToString());
                if (Repositorio == null)
                    return NotFound();
                else
                    return new ObjectResult(Repositorio);
            }
        }




    }
}