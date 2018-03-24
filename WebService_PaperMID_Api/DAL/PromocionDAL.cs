using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class PromocionDAL
    {
        ConexionDAL _oConexionDAL;
        public PromocionDAL() { _oConexionDAL = new ConexionDAL(); }

        public int Agregar(object Obj)
        {
            PromocionModel _oModel = (PromocionModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Promocion @NombrePromo,@DescripcionPromo,@DescuentoPromo,@FechaInicioPromo,@FechaFinPromo,@IdProveedor1");
            Cmd.Parameters.Add("@NombrePromo", SqlDbType.VarChar).Value = _oModel.NombrePromo;
            Cmd.Parameters.Add("@DescuentoPromo", SqlDbType.Float).Value = _oModel.DescuentoPromo;
            Cmd.Parameters.Add("@DescripcionPromo", SqlDbType.VarChar).Value = _oModel.DescripcionPromo;
            Cmd.Parameters.Add("@FechaInicioPromo", SqlDbType.VarChar).Value = _oModel.FechaInicioPromo;
            Cmd.Parameters.Add("@FechaFinPromo", SqlDbType.VarChar).Value = _oModel.FechaFinPromo;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oModel.IdProveedor1;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_EliminarPromocion @IdPromocion");
            Cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            PromocionModel _oModel = (PromocionModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Promocion @IdPromocion,@NombrePromo,@DescripcionPromo,@DescuentoPromo,@FechaInicioPromo,@FechaFinPromo,@IdProveedor1");
            Cmd.Parameters.Add("@IdPromocion", SqlDbType.Int).Value = _oModel.IdPromocion;
            Cmd.Parameters.Add("@NombrePromo", SqlDbType.VarChar).Value = _oModel.NombrePromo;
            Cmd.Parameters.Add("@DescuentoPromo", SqlDbType.Float).Value = _oModel.DescuentoPromo;
            Cmd.Parameters.Add("@DescripcionPromo", SqlDbType.VarChar).Value = _oModel.DescripcionPromo;
            Cmd.Parameters.Add("@FechaInicioPromo", SqlDbType.VarChar).Value = _oModel.FechaInicioPromo;
            Cmd.Parameters.Add("@FechaFinPromo", SqlDbType.VarChar).Value = _oModel.FechaFinPromo;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oModel.IdProveedor1;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }
        public List<PromocionModel> TablaPromociones()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Promociones");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<PromocionModel> Promociones = new List<PromocionModel>();
                foreach (DataRow Promocion in Resultado.Rows)
                {
                    var _oPromocionModel = new PromocionModel()
                    {
                        IdPromocion = int.Parse(Promocion[0].ToString()),
                        NombrePromo = Promocion[1].ToString(),
                        DescripcionPromo = Promocion[2].ToString(),
                        DescuentoPromo = Convert.ToDouble(Promocion[3].ToString()),
                        FechaInicioPromo = Promocion[4].ToString(),
                        FechaFinPromo = Promocion[5].ToString(),
                        IdProveedor1 = int.Parse(Promocion[6].ToString())
                    };
                    Promociones.Add(_oPromocionModel);
                }
                return Promociones;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public PromocionModel Recuperar_Promo(long IdPromocion)
        {
            try
            {
                string Query = String.Format("SELECT * FROM Vst_Lista_Promociones WHERE IdPromocion='{0}'", IdPromocion);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                var oPromocionModel = new PromocionModel()
                {
                    IdPromocion = Convert.ToInt32(Row["IdPromocion"]),
                    NombrePromo = Row["NombrePromo"].ToString(),
                    DescuentoPromo = Convert.ToDouble(Row["DescuentoPromo"].ToString()),
                    DescripcionPromo = Row["DescripcionPromo"].ToString(),
                    FechaInicioPromo = Row["FechaInicioPromo"].ToString(),
                    FechaFinPromo = Row["FechaFinPromo"].ToString(),
                    IdProveedor1 = Convert.ToInt32(Row["IdProveedor1"])
                };
                return oPromocionModel;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
