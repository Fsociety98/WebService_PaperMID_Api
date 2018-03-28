using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class LoginDAL
    {

        ConexionDAL _oConexionDAL;
        public LoginDAL() { _oConexionDAL = new ConexionDAL(); }

        //Seguridad - Encriptado.
        public string Encriptar(string str) //MD5
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }

        public Login_RespuestaModel Comprobar_Usuario(Login_ComprobacionModel _oLoginComprobacionModel)
        {
            try
            {
                SqlCommand Cmd = new SqlCommand("EXEC SP_Login @Usuario,@ContraseñaUsu", _oConexionDAL.EstablecerConexion());
                Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = _oLoginComprobacionModel.Usuario;
                Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = Encriptar(_oLoginComprobacionModel.ContraseñaUsu);
                string encrip = Encriptar(_oLoginComprobacionModel.ContraseñaUsu);
                Cmd.CommandType = CommandType.Text;
                var _oLogin_RespuestaModel = new Login_RespuestaModel();
                //Recolección de datos.
                _oConexionDAL.AbrirConexion();
                SqlDataReader Datos = Cmd.ExecuteReader();
                while (Datos.Read())
                {
                    _oLogin_RespuestaModel.IdUsuario = int.Parse(Datos[0].ToString());
                    _oLogin_RespuestaModel.Modulo = Datos[3].ToString();
                    _oLogin_RespuestaModel.NombreUsu = Datos[4].ToString();

                }
                _oConexionDAL.CerrarConexion();
                //Comprobación.
                return (_oLogin_RespuestaModel.IdUsuario > 0) ? _oLogin_RespuestaModel : null;
 
            }
            catch (Exception)
            {

                return null;
            }

        }        
    }
}
