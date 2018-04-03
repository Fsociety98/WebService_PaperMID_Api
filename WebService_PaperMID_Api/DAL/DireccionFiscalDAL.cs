using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;


namespace WebService_PaperMID_Api.DAL
{
    public class DireccionFiscalDAL
    {
        ConexionDAL _oConexionDAL;

        public DireccionFiscalDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }

        public int Agregar(object Obj)
        {
            DireccionFiscalModel _oModel = (DireccionFiscalModel)Obj;
            SqlCommand Cmd = new SqlCommand("insert into DireccionFiscal values (@CalleDirFis,@NumInteDirFis,@NumExteDirFis,@CruzaDirFis,@ColoniaDirFis,@CPDirFis,@UbicacionDirFis,@LatitudDirFis,@LongitudDisFis,@IdMunicipio4,@FechaRegistroDirFis,@StatusDirFis,@CompletoDisFis)");
            //@CalleDirFis,@NumInteDirFis,@NumExteDirFis,@CruzaDirFis,@ColoniaDirFis,@CPDirFis,@UbicacionDirFis,@LatitudDirFis,@LongitudDisFis,@IdMunicipio4,@FechaRegistroDirFis,@StatusDirFis,@CompletoDisFis
            Cmd.Parameters.Add("@CalleDirFis", SqlDbType.VarChar).Value = _oModel.CalleDirFis;
            Cmd.Parameters.Add("@NumInteDirFis", SqlDbType.VarChar).Value = _oModel.NumInteDirFis;
            Cmd.Parameters.Add("@NumExteDisFis", SqlDbType.VarChar).Value = _oModel.NumExteDirFis;
            Cmd.Parameters.Add("@CruzaDirFis", SqlDbType.VarChar).Value = _oModel.CruzaDirFis;
            Cmd.Parameters.Add("@ColoniaDirFis", SqlDbType.VarChar).Value = _oModel.ColoniaDirFis;
            Cmd.Parameters.Add("@CPDirDirFis", SqlDbType.VarChar).Value = _oModel.CPDirFis;
            Cmd.Parameters.Add("@UbicacionDirFis", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@LatitudDirFis", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@LongitudDisFis", SqlDbType.VarChar).Value = 0;
            Cmd.Parameters.Add("@IdMunicipio4", SqlDbType.Int).Value = 1; //Mérida
            string comple = (_oModel.CalleDirFis + " Num. int " + _oModel.NumInteDirFis + " Num ext." + _oModel.NumExteDirFis + " por " + _oModel.CruzaDirFis + " " + _oModel.ColoniaDirFis + " " + _oModel.CPDirFis);
            Cmd.Parameters.Add("@CompletoDirFis", SqlDbType.VarChar).Value = comple;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public int Modificar(object Obj)
        {
            DireccionFiscalModel _oModel = (DireccionFiscalModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Direccion_Fiscal @IdDireccion,@CalleDir,@NumInteDir,@NumExteDir,@CruzaDir,@ColoniaDir,@CPDir,@UbicacionDir,@LatitudDir,@LongitudDir,@IdMunicipio1,@Completo");
            Cmd.Parameters.Add("@IdDireccion", SqlDbType.Int).Value = _oModel.IdDireccionFiscal;
            Cmd.Parameters.Add("@CalleDir", SqlDbType.VarChar).Value = _oModel.CalleDirFis;
            Cmd.Parameters.Add("@NumInteDir", SqlDbType.VarChar).Value = _oModel.NumInteDirFis;
            Cmd.Parameters.Add("@NumExteDir", SqlDbType.VarChar).Value = _oModel.NumExteDirFis;
            Cmd.Parameters.Add("@CruzaDir", SqlDbType.VarChar).Value = _oModel.CruzaDirFis;
            Cmd.Parameters.Add("@ColoniaDir", SqlDbType.VarChar).Value = _oModel.ColoniaDirFis;
            Cmd.Parameters.Add("@CPDir", SqlDbType.VarChar).Value = _oModel.CPDirFis;
            Cmd.Parameters.Add("@UbicacionDir", SqlDbType.VarChar).Value = _oModel.UbicacionDirFis;
            Cmd.Parameters.Add("@LatitudDir", SqlDbType.VarChar).Value = _oModel.LatitudDirFis;
            Cmd.Parameters.Add("@LongitudDir", SqlDbType.VarChar).Value = _oModel.LongitudDirFis;
            Cmd.Parameters.Add("@IdMunicipio1", SqlDbType.Int).Value = 1; //Mérida
            string comple = (_oModel.CalleDirFis + " Num. int " + _oModel.NumInteDirFis + " Num ext." + _oModel.NumExteDirFis + " por " + _oModel.CruzaDirFis + " " + _oModel.ColoniaDirFis + " " + _oModel.CPDirFis);
            Cmd.Parameters.Add("@Completo", SqlDbType.VarChar).Value = comple;
            Cmd.CommandType = CommandType.Text;
            return _oConexionDAL.EjecutarSQL(Cmd);
        }

        public List<DireccionFiscalModel> TablasDireccionesFiscales()
        {
            try
            {
                string Query = ("select * from DireccionFiscal where StatusDirFis=1");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<DireccionFiscalModel> DireccionesFiscales = new List<DireccionFiscalModel>();
                foreach (DataRow DireccionFiscal in Resultado.Rows)
                {
                    var _oDireccionFiscalModel = new DireccionFiscalModel()
                    {
                        IdDireccionFiscal = int.Parse(DireccionFiscal[0].ToString()),
                        CalleDirFis = DireccionFiscal[1].ToString(),
                        NumInteDirFis = DireccionFiscal[2].ToString(),
                        NumExteDirFis = DireccionFiscal[3].ToString(),
                        CruzaDirFis = DireccionFiscal[4].ToString(),
                        ColoniaDirFis = DireccionFiscal[5].ToString(),
                        CPDirFis = DireccionFiscal[6].ToString(),
                        CompletoDirFis = DireccionFiscal[11].ToString(),
                        IdMunicipio4 = int.Parse(DireccionFiscal[7].ToString())
                    };
                    DireccionesFiscales.Add(_oDireccionFiscalModel);
                }
                return DireccionesFiscales;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public DireccionFiscalModel Recuperar_DirFis(long IdDirFis)
        {
            try
            {
                string Query = String.Format("select * from Mensaje where IdMensaje='{0}' and Estatus=0", IdDirFis);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                var oDireccionFiscalModel = new DireccionFiscalModel()
                {
                    IdDireccionFiscal = Convert.ToInt32(Row["IdMensaje"]),
                    CalleDirFis = Row["Mensaje"].ToString(),
                    NumInteDirFis = Row["Nombre"].ToString(),
                    NumExteDirFis = Row["Asunto"].ToString(),
                    CruzaDirFis = Row["Telefono"].ToString(),
                    ColoniaDirFis = Row["Correo"].ToString(),
                    CPDirFis = Row[""].ToString(),
                    IdMunicipio4 = Convert.ToInt32(Row["Usuario"]),
                    CompletoDirFis = Row["CompleroDirFis"].ToString()
                };
                return oDireccionFiscalModel;
            }
            catch (Exception)
            {

                return null;
            }
        }



    }
}
