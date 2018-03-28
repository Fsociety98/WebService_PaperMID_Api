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
    public class UsuarioDAL
    {
        ConexionDAL oConexionDAL;
        public UsuarioDAL()
        {
            oConexionDAL = new ConexionDAL();
        }
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
        //SQL
        public int Buscar_IdDireccion()
        {
            SqlCommand Cmd = new SqlCommand("SELECT Max(IdDireccion) FROM Direccion")
            {
                CommandType = CommandType.Text
            };
            return oConexionDAL.EjecutarSQL(Cmd);
        }
  
        public int Agregar(object Obj)
        {
            UsuarioModel oUsuarioModel = (UsuarioModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Usuario @Usuario, @ContraseñaUsu, @NombreUsu, @ApellidoPaternoUsu, @ApellidoMaternoUsu,@RFCUsu,@RazonSocioUsu, @TelefonoUsu, @CorreoUsu, @IdTipoUsuario1,@IdDireccion2");
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oUsuarioModel.Usuario;
            Cmd.Parameters.Add("@ContraseñaUsu", SqlDbType.VarChar).Value = Encriptar(oUsuarioModel.ContraseñaUsu);
            Cmd.Parameters.Add("@NombreUsu", SqlDbType.VarChar).Value = oUsuarioModel.NombreUsu;
            Cmd.Parameters.Add("@ApellidoPaternoUsu", SqlDbType.VarChar).Value = oUsuarioModel.ApellidoPaternoUsu;
            Cmd.Parameters.Add("@ApellidoMaternoUsu", SqlDbType.VarChar).Value = oUsuarioModel.ApellidoMaternoUsu;
            Cmd.Parameters.Add("@RFCUsu", SqlDbType.VarChar).Value = oUsuarioModel.RFCUsu;
            Cmd.Parameters.Add("@RazonSocioUsu", SqlDbType.VarChar).Value = oUsuarioModel.RazonSocioUsu;
            Cmd.Parameters.Add("@TelefonoUsu", SqlDbType.VarChar).Value = oUsuarioModel.TelefonoUsu;
            Cmd.Parameters.Add("@CorreoUsu", SqlDbType.VarChar).Value = oUsuarioModel.CorreoUsu;
            Cmd.Parameters.Add("@IdTipoUsuario1", SqlDbType.Int).Value = oUsuarioModel.IdTipoUsuario1;
            Cmd.Parameters.Add("@IdDireccion2", SqlDbType.Int).Value = Buscar_IdDireccion();
            Cmd.CommandType = CommandType.Text;
            return oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Usuario @IdUsuario");
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = Convert.ToInt32(Obj);
            Cmd.CommandType = CommandType.Text;
            return oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            UsuarioModel oUsuarioModel = (UsuarioModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Usuario @IdUsuario, @Usuario, @NombreUsu, @ApellidoPaternoUsu, @ApellidoMaternoUsu, @RFCUsu, @RazonSocioUsu, @TelefonoUsu, @CorreoUsu");
            Cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = oUsuarioModel.IdUsuario;
            Cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = oUsuarioModel.Usuario;
            Cmd.Parameters.Add("@NombreUsu", SqlDbType.VarChar).Value = oUsuarioModel.NombreUsu;
            Cmd.Parameters.Add("@ApellidoPaternoUsu", SqlDbType.VarChar).Value = oUsuarioModel.ApellidoPaternoUsu;
            Cmd.Parameters.Add("@ApellidoMaternoUsu", SqlDbType.VarChar).Value = oUsuarioModel.ApellidoMaternoUsu;
            Cmd.Parameters.Add("@RFCUsu", SqlDbType.VarChar).Value = oUsuarioModel.RFCUsu;
            Cmd.Parameters.Add("@RazonSocioUsu", SqlDbType.VarChar).Value = oUsuarioModel.RazonSocioUsu;
            Cmd.Parameters.Add("@TelefonoUsu", SqlDbType.VarChar).Value = oUsuarioModel.TelefonoUsu;
            Cmd.Parameters.Add("@CorreoUsu", SqlDbType.VarChar).Value = oUsuarioModel.CorreoUsu;
            Cmd.CommandType = CommandType.Text;
            return oConexionDAL.EjecutarSQL(Cmd);
        }

        public List<UsuarioModel> TablaUsuarios()
        {
            try
            {
                string Query = string.Format("SELECT * FROM Vst_Lista_Usuarios WHERE IdTipoUsuario1='{0}'",2);
                var Resultado = oConexionDAL.TablaConnsulta(Query);
                List<UsuarioModel> Usuarios = new List<UsuarioModel>();
                foreach (DataRow Usuario in Resultado.Rows)
                {
                    var _oUsuarioModel = new UsuarioModel()
                    {
                        IdUsuario = Convert.ToInt32(Usuario[0].ToString()),
                        Usuario = Usuario[1].ToString(),
                        NombreUsu = Usuario[3].ToString(),
                        ApellidoPaternoUsu = Usuario[4].ToString(),
                        ApellidoMaternoUsu = Usuario[5].ToString(),
                        RFCUsu = Usuario[6].ToString(),
                        RazonSocioUsu = Usuario[7].ToString(),
                        TelefonoUsu = Usuario[8].ToString(),
                        CorreoUsu = Usuario[9].ToString(),
                        IdTipoUsuario1 = Convert.ToInt32(Usuario[11].ToString()),
                        IdDireccion2 = Convert.ToInt32(Usuario[12].ToString())
                    };
                    Usuarios.Add(_oUsuarioModel);
                }
                return Usuarios;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public UsuarioModel Obtener_Usuario(long IdUsuario)
        {
            try
            {
                var oUsuarioModel = new UsuarioModel();
                String Query = string.Format("SELECT * FROM Vst_Lista_Usuarios WHERE IdUsuario='{0}'", IdUsuario);
                var Resultado = oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow row = Datos.Rows[0];
                oUsuarioModel.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                oUsuarioModel.Usuario = row["Usuario"].ToString();
                oUsuarioModel.NombreUsu = row["NombreUsu"].ToString();
                oUsuarioModel.ApellidoPaternoUsu = row["ApellidoPaternoUsu"].ToString();
                oUsuarioModel.ApellidoMaternoUsu = row["ApellidoMaternoUsu"].ToString();
                oUsuarioModel.RFCUsu = row["RFCUsu"].ToString();
                oUsuarioModel.RazonSocioUsu = row["RazonSocioUsu"].ToString();
                oUsuarioModel.TelefonoUsu = row["TelefonoUsu"].ToString();
                oUsuarioModel.CorreoUsu = row["CorreoUsu"].ToString();
                oUsuarioModel.IdTipoUsuario1 = Convert.ToInt32(row["IdTipoUsuario1"].ToString());
                oUsuarioModel.IdDireccion2 = Convert.ToInt32(row["IdDireccion2"]);
                return oUsuarioModel;
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}

