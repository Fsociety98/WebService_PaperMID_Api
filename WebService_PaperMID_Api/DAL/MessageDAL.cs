using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;


namespace WebService_PaperMID_Api.DAL
{
    public class MessageDAL
    {
        ConexionDAL _oConexionDAL;
        public MessageDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }

        public int AgregarPublico(object Obj)
        {
            Models.MensajeModels _oMensajeModel = (Models.MensajeModels)Obj;
            SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[Mensaje]([Mensaje],[Nombre],[Asunto],[Telefono],[Correo],[Usuario],[Estatus]) VALUES (@Mensaje,@Nombre,@Asunto,@Telefono,@Correo,@Usuario,@Estatus)");
            //@Mensaje,@Asunto,@Telefono,@Correo,@Usuario,@Estatus,@Nombre
            Cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = _oMensajeModel.Mensaje;
            Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = _oMensajeModel.Nombre;
            Cmd.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = _oMensajeModel.Asunto;
            Cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = _oMensajeModel.Telefono;
            Cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = _oMensajeModel.Correo;
            Cmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = 11;
            Cmd.Parameters.Add("@Estatus", SqlDbType.Int).Value = 0;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        //public int AgregarCliente(object Obj)
        //{
        //    Models.MensajeModels _oMensajeModel = (Models.MensajeModels)Obj;
        //    SqlCommand Cmd = new SqlCommand("INSERT INTO [dbo].[Mensaje]([Mensaje],[Nombre],[Asunto],[Telefono],[Correo],[Usuario],[Estatus]) VALUES (@Mensaje,@Nombre,@Asunto,@Telefono,@Correo,@Usuario,@Estatus)");
        //    //@Mensaje,@Asunto,@Telefono,@Correo,@Usuario,@Estatus,@Nombre
        //    Cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = _oMensajeModel.Mensaje;
        //    Cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = _oMensajeModel.Nombre;
        //    Cmd.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = _oMensajeModel.Asunto;
        //    Cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = _oMensajeModel.Telefono;
        //    Cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = _oMensajeModel.Correo;
        //    Cmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = _oMensajeModel.Usuario;
        //    Cmd.Parameters.Add("@Estatus", SqlDbType.Int).Value = 0;
        //    Cmd.CommandType = CommandType.Text;
        //    return _oConexionDAL.EjecutarSQL(Cmd);
        //}


        public List<MensajeModels> TablaMensajes()
        {
            try
            {
                string Query = ("select * from Mensaje where Estatus=0");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<MensajeModels> Mensajes = new List<MensajeModels>();
                foreach (DataRow Mensaje in Resultado.Rows)
                {
                    var _oMensajeModels = new MensajeModels()
                    {
                        IdMensaje = int.Parse(Mensaje[0].ToString()),
                        Mensaje = Mensaje[1].ToString(),
                        Nombre = Mensaje[2].ToString(),
                        Asunto = Mensaje[3].ToString(),
                        Telefono = Mensaje[4].ToString(),
                        Correo = Mensaje[5].ToString(),
                        Usuario = int.Parse( Mensaje[6].ToString())
                    };
                    Mensajes.Add(_oMensajeModels);
                }
                return Mensajes;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public MensajeModels Recuperar_Mensa(long IdMensaje)
        {
            try
            {
                string Query = String.Format("select * from Mensaje where IdMensaje='{0}' and Estatus=0", IdMensaje);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                var oMensajeModels = new MensajeModels()
                {
                    IdMensaje = Convert.ToInt32(Row["IdMensaje"]),
                    Mensaje = Row["Mensaje"].ToString(),
                    Nombre = Row["Nombre"].ToString(),
                    Asunto = Row["Asunto"].ToString(),
                    Telefono = Row["Telefono"].ToString(),
                    Correo = Row["Correo"].ToString(),
                    Usuario = Convert.ToInt32(Row["Usuario"])
                };
                return oMensajeModels;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public DataTable MostrarMensajesPendientes()
        {
            return _oConexionDAL.TablaConnsulta("select * from Mensaje where Estatus=0"); //Todos los Mensajes Pendientes
        }

    }
}
