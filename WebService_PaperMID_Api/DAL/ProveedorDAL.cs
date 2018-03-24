using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;
namespace WebService_PaperMID_Api.DAL
{
    public class ProveedorDAL
    {
        ConexionDAL _oConexionDAL;

        public ProveedorDAL() { _oConexionDAL = new ConexionDAL(); }

        public int Agregar(object Obj)
        {
            ProveedorModel _oModel = (ProveedorModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Proveedor @NombreProv,@TelefonoProv,@CorreoProv");
            Cmd.Parameters.Add("@NombreProv", SqlDbType.VarChar).Value = _oModel.NombreProv;
            Cmd.Parameters.Add("@TelefonoProv", SqlDbType.VarChar).Value = _oModel.TelefonoProv;
            Cmd.Parameters.Add("@CorreoProv", SqlDbType.VarChar).Value = _oModel.CorreoProv;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Proveedor @IdProveedor");
            Cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            ProveedorModel _oModel = (ProveedorModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Proveedor @IdProveedor,@NombreProv,@TelefonoProv,@CorreoProv ");
            Cmd.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = _oModel.IdProveedor;
            Cmd.Parameters.Add("@NombreProv", SqlDbType.VarChar).Value = _oModel.NombreProv;
            Cmd.Parameters.Add("@TelefonoProv", SqlDbType.VarChar).Value = _oModel.TelefonoProv;
            Cmd.Parameters.Add("@CorreoProv", SqlDbType.VarChar).Value = _oModel.CorreoProv;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }


        public List<ProveedorModel> TablaProveedores()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Proveedores");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<ProveedorModel> Proveedores = new List<ProveedorModel>();
                foreach (DataRow proveedor in Resultado.Rows)
                {
                    var _oProveedorModel = new ProveedorModel()
                    {
                        IdProveedor = int.Parse(proveedor[0].ToString()),
                        NombreProv = proveedor[1].ToString(),
                        TelefonoProv = proveedor[2].ToString(),
                        CorreoProv = proveedor[3].ToString(),
                        FechaRegistroProv=Convert.ToDateTime(proveedor[4].ToString()),
                        StatusProv=Convert.ToBoolean(proveedor[5].ToString())
                    };
                    Proveedores.Add(_oProveedorModel);
                }
                return Proveedores;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public ProveedorModel Recuperar_Proveedor(long IdProveedor)
        {
            try
            {
                var _oProveedorModel = new ProveedorModel();
                string Query = string.Format("SELECT * FROM Vst_Lista_Proveedores WHERE IdProveedor='{0}'", IdProveedor);
                var Resultado= _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                _oProveedorModel.IdProveedor = Convert.ToInt32(Row["IdProveedor"]);
                _oProveedorModel.NombreProv = Row["NombreProv"].ToString();
                _oProveedorModel.TelefonoProv = Row["TelefonoProv"].ToString();
                _oProveedorModel.CorreoProv = Row["CorreoProv"].ToString();
                _oProveedorModel.FechaRegistroProv = Convert.ToDateTime(Row["FechaRegistroProv"].ToString());
                _oProveedorModel.StatusProv = Convert.ToBoolean(Row["StatusProv"].ToString());
                return _oProveedorModel;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
