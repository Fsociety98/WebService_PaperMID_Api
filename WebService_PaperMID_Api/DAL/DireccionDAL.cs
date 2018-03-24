using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class DireccionDAL
    {
        ConexionDAL _oConexionDAL;

        public DireccionDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }
        public int Agregar(object Obj)
        {
            DireccionModel _oModel = (DireccionModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Direccion @CalleDir,@NumInteDir,@NumExteDir,@CruzaDir,@ColoniaDir,@CPDir,@UbicacionDir,@LatitudDir,@LongitudDir,@IdMunicipio1,@Completo");
            Cmd.Parameters.Add("@CalleDir", SqlDbType.VarChar).Value = _oModel.CalleDir;
            Cmd.Parameters.Add("@NumInteDir", SqlDbType.VarChar).Value = _oModel.NumInteDir;
            Cmd.Parameters.Add("@NumExteDir", SqlDbType.VarChar).Value = _oModel.NumExteDir;
            Cmd.Parameters.Add("@CruzaDir", SqlDbType.VarChar).Value = _oModel.CruzaDir;
            Cmd.Parameters.Add("@ColoniaDir", SqlDbType.VarChar).Value = _oModel.ColoniaDir;
            Cmd.Parameters.Add("@CPDir", SqlDbType.VarChar).Value = _oModel.CPDir;
            Cmd.Parameters.Add("@UbicacionDir", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@LatitudDir", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@LongitudDir", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@IdMunicipio1", SqlDbType.Int).Value = 1; //Mérida
            string comple = (_oModel.CalleDir + " Num. int " + _oModel.NumInteDir + " Num ext." + _oModel.NumExteDir + " por " + _oModel.CruzaDir + " " + _oModel.ColoniaDir + " " + _oModel.CPDir);
            Cmd.Parameters.Add("@Completo", SqlDbType.VarChar).Value = comple;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            DireccionModel _oModel = (DireccionModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Direccion @IdDireccion");
            Cmd.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = _oModel.IdDireccion;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            DireccionModel _oModel = (DireccionModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Direccion @IdDireccion,@CalleDir,@NumInteDir,@NumExteDir,@CruzaDir,@ColoniaDir,@CPDir,@UbicacionDir,@LatitudDir,@LongitudDir,@IdMunicipio1,@Completo");
            Cmd.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = _oModel.IdDireccion;
            Cmd.Parameters.Add("@CalleDir", SqlDbType.VarChar).Value = _oModel.CalleDir;
            Cmd.Parameters.Add("@NumInteDir", SqlDbType.VarChar).Value = _oModel.NumInteDir;
            Cmd.Parameters.Add("@NumExteDir", SqlDbType.VarChar).Value = _oModel.NumExteDir;
            Cmd.Parameters.Add("@CruzaDir", SqlDbType.VarChar).Value = _oModel.CruzaDir;
            Cmd.Parameters.Add("@ColoniaDir", SqlDbType.VarChar).Value = _oModel.ColoniaDir;
            Cmd.Parameters.Add("@CPDir", SqlDbType.VarChar).Value = _oModel.CPDir;
            Cmd.Parameters.Add("@UbicacionDir", SqlDbType.VarChar).Value = _oModel.UbicacionDir;
            Cmd.Parameters.Add("@LatitudDir", SqlDbType.VarChar).Value = _oModel.LatitudDir;
            Cmd.Parameters.Add("@LongitudDir", SqlDbType.VarChar).Value = _oModel.LongitudDir;
            Cmd.Parameters.Add("@IdMunicipio1", SqlDbType.Int).Value = 1; //Mérida
            string comple = (_oModel.CalleDir + " Num. int " + _oModel.NumInteDir + " Num ext." + _oModel.NumExteDir + " por " + _oModel.CruzaDir + " " + _oModel.ColoniaDir + " " + _oModel.CPDir);
            Cmd.Parameters.Add("@Completo", SqlDbType.VarChar).Value = comple;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public List<DireccionModel> TablaDirecciones()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Direccion");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<DireccionModel> Direcciones = new List<DireccionModel>();
                foreach (DataRow Direccion in Resultado.Rows)
                {
                    var _oDireccionModel = new DireccionModel()
                    {
                        IdDireccion = int.Parse(Direccion[0].ToString()),
                        CalleDir = Direccion[1].ToString(),
                        NumInteDir = Direccion[2].ToString(),
                        NumExteDir = Direccion[3].ToString(),
                        CruzaDir= Direccion[4].ToString(),
                        ColoniaDir = Direccion[5].ToString(),
                        CPDir= Direccion[6].ToString(),
                        UbicacionDir= Direccion[7].ToString(),
                        LatitudDir= Direccion[8].ToString(),
                        LongitudDir= Direccion[9].ToString(),
                        IdMunicipio1 =int.Parse(Direccion[10].ToString())
                    };
                    Direcciones.Add(_oDireccionModel);
                }
                return Direcciones;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DireccionModel Obtener_Direccion(long IdDireccion)
        {
            try
            {
                var oDireccionModel = new DireccionModel();
                String Query = string.Format("SELECT * FROM Vst_Lista_Direccion WHERE IdDireccion='{0}'", IdDireccion);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow row = Datos.Rows[0];
                oDireccionModel.IdDireccion = Convert.ToInt32(row["IdDireccion"]);
                oDireccionModel.CalleDir = row["CalleDir"].ToString();
                oDireccionModel.NumInteDir = row["NumInteDir"].ToString();
                oDireccionModel.NumExteDir = row["NumExteDir"].ToString();
                oDireccionModel.CruzaDir = row["CruzaDir"].ToString();
                oDireccionModel.ColoniaDir = row["ColoniaDir"].ToString();
                oDireccionModel.CPDir = row["CPDir"].ToString();
                oDireccionModel.UbicacionDir = row["UbicacionDir"].ToString();
                oDireccionModel.LongitudDir = row["LongitudDir"].ToString();
                oDireccionModel.LatitudDir = row["LatitudDir"].ToString();
                return oDireccionModel;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
