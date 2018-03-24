using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class TipoProductoDAL
    {
        ConexionDAL _oConexion;
        public TipoProductoDAL() { _oConexion = new ConexionDAL(); }

        public int Agregar(object Obj)
        {
            TipoProductoModel _oModel = (TipoProductoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_TipoProducto @TipoProd");
            Cmd.Parameters.Add("@TipoProd", SqlDbType.VarChar).Value = _oModel.TipoProducto;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {

            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_TipoProducto @IdTipoProducto");
            Cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            TipoProductoModel _oModel = (TipoProductoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_TipoProducto @IdTipoProducto,@TipoProd");
            Cmd.Parameters.Add("@IdTipoProducto", SqlDbType.Int).Value = _oModel.IdTipoProducto;
            Cmd.Parameters.Add("@TipoProd", SqlDbType.VarChar).Value = _oModel.TipoProducto;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public List<TipoProductoModel> TabTipoProd()
        {
            try
            {
                string Query = "SELECT * FROM Vst_Lista_TipoProducto";
                var Resultado = _oConexion.TablaConnsulta(Query);
                List<TipoProductoModel> TiposProducto = new List<TipoProductoModel>();
                foreach (DataRow TipoProd in Resultado.Rows)
                {
                    var TipoProdModel = new TipoProductoModel()
                    {
                        IdTipoProducto = int.Parse(TipoProd[0].ToString()),
                        TipoProducto = TipoProd[1].ToString(),
                        Fecha_Reg = Convert.ToDateTime(TipoProd[2].ToString()),
                        Status = Convert.ToBoolean(TipoProd[3].ToString())
                    };
                    TiposProducto.Add(TipoProdModel);
                }
                return TiposProducto;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public TipoProductoModel RecuperarTipo(long IdTipoProducto)
        {
            try
            {
                var tPro = new TipoProductoModel();
                string BuscarTipo = string.Format("SELECT * FROM Vst_Lista_TipoProducto WHERE IdTipoProducto='{0}'", IdTipoProducto);
                DataTable Datos = _oConexion.TablaConnsulta(BuscarTipo);
                DataRow Row = Datos.Rows[0];
                tPro.IdTipoProducto = Convert.ToInt32(Row["IdTipoProducto"]);
                tPro.TipoProducto = Row["TipoProd"].ToString();
                tPro.Fecha_Reg = Convert.ToDateTime(Row["FechaRegistroTpro"].ToString());
                tPro.Status = Convert.ToBoolean(Row["StatusTpro"].ToString());
                return tPro;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
