using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class EgresoDAL
    {
        ConexionDAL _oConexionDAL;
        public EgresoDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }

        public int Agregar(object Obj)
        {
            EgresoModel _oModel = (EgresoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Egreso @IdProducto,@CantidadEgresada,@IdTipoEgreso");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar).Value = _oModel.IdProducto;
            Cmd.Parameters.Add("@CantidadEgresada", SqlDbType.VarChar).Value = _oModel.CantidadEgresada;
            Cmd.Parameters.Add("@IdTipoEgreso", SqlDbType.VarChar).Value = _oModel.IdTipoEgreso;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Egreso @IdEgreso");
            Cmd.Parameters.Add("@IdEgreso", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public List<Vst_EgresoModel> TablaEgresos()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Egresos");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<Vst_EgresoModel> LstIngresos = new List<Vst_EgresoModel>();
                foreach (DataRow Egreso in Resultado.Rows)
                {
                    var _oVst_IngresoModel = new Vst_EgresoModel()
                    {
                        IdEgreso = int.Parse(Egreso[0].ToString()),
                        CódigoProd = Egreso[1].ToString(),
                        NombreProd = Egreso[2].ToString(),
                        CantidadEgresada = int.Parse(Egreso[3].ToString()),
                        TipoEgreso = Egreso[4].ToString()
                    };
                    LstIngresos.Add(_oVst_IngresoModel);
                }
                return LstIngresos;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
