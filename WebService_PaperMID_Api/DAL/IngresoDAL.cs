using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class IngresoDAL
    {
        ConexionDAL _oConexionDAL;
        public IngresoDAL() {
            _oConexionDAL = new ConexionDAL();
        }

        public int Agregar(object Obj)
        {
            IngresoModel _oModel = (IngresoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Ingreso @IdProducto,@CantidadIngresada,@IdTipoIngreso");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar).Value = _oModel.IdProducto;
            Cmd.Parameters.Add("@CantidadIngresada", SqlDbType.VarChar).Value = _oModel.CantidadIngresada;
            Cmd.Parameters.Add("@IdTipoIngreso", SqlDbType.VarChar).Value = _oModel.IdTipoIngreso;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Ingreso @IdIngreso");
            Cmd.Parameters.Add("@IdIngreso", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public List<Vst_IngresoModel> TablaIngresos()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Ingresos");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<Vst_IngresoModel> LstIngresos = new List<Vst_IngresoModel>();
                foreach (DataRow Ingreso in Resultado.Rows)
                {
                    var _oVst_IngresoModel = new Vst_IngresoModel()
                    {
                        IdIngreso = int.Parse(Ingreso[0].ToString()),
                        CódigoProd = Ingreso[1].ToString(),
                        NombreProd = Ingreso[2].ToString(),
                        CantidadIngresada = int.Parse(Ingreso[3].ToString()),
                        TipoIngreso = Ingreso[4].ToString()
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
        public IngresoModel Recuperar_Ingreso(long IdIngreso)
        {
            string Query = String.Format("SELECT * FROM Ingresos WHERE IdIngreso=('{0}') AND StatusIngreso=1", IdIngreso);
            var Resultado = _oConexionDAL.TablaConnsulta(Query);
            DataTable Datos = Resultado;
            DataRow Row = Datos.Rows[0];
            var oIngresoModel = new IngresoModel()
            {
                IdIngreso = Convert.ToInt32(Row["IdIngreso"]),
                IdProducto = Convert.ToInt32(Row["IdProducto"]),
                IdTipoIngreso = Convert.ToInt32(Row["IdTipoIngreso"]),
                CantidadIngresada = Convert.ToInt32(Row["CantidadIngresada"])
            };
            return oIngresoModel;
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    return null;
            //}
        }
    }
}
