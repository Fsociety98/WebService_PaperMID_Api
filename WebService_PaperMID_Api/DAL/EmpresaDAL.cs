using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class EmpresaDAL
    {
        ConexionDAL _oConexion;
        public EmpresaDAL()
        {
            _oConexion = new ConexionDAL();
        }
        public int Modificar(object Obj)
        {
            Models.EmpresaModel Model = (Models.EmpresaModel)Obj;
            SqlCommand Cmd = new SqlCommand("UPDATE [dbo].[Papeleria] SET [NombrePape] = @NombrePape,[MisionPape] = @MisionPape,[VisionPape] = @VisionPape,[ValoresPape] = @ValoresPape,[CorreoPape] = @CorreoPape,[TelefenoPape] = @TelefenoPape WHERE IdPapeleria=@IdPapeleria");
            //@ImagenLogoEmpre ,@ValoresEmpre,@CorreoEmpre,@TelefenoEmpre,@FacebookEmpre,@IdDireccion1 ,[FacebookEmpre] = @FacebookEmpre,[IdDireccion1] = @IdDireccion1
            Cmd.Parameters.Add("@IdPapeleria", SqlDbType.Int).Value = Model.IdPapeleria;
            Cmd.Parameters.Add("@NombrePape", SqlDbType.VarChar).Value = Model.NombrePape;
            Cmd.Parameters.Add("@MisionPape", SqlDbType.VarChar).Value = Model.MisionPape;
            Cmd.Parameters.Add("@VisionPape", SqlDbType.VarChar).Value = Model.VisionPape;
            Cmd.Parameters.Add("@ValoresPape", SqlDbType.VarChar).Value = Model.ValoresPape;
            Cmd.Parameters.Add("@CorreoPape", SqlDbType.VarChar).Value = Model.CorreoPape;
            Cmd.Parameters.Add("@TelefenoPape", SqlDbType.VarChar).Value = Model.TelefenoPape;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public EmpresaModel Obtener_Empresa(long id)
        {
            try
            {
                var Empresa = new EmpresaModel();
                var StrBuscar = string.Format("Select * from Papeleria where IdPapeleria= 1");
                var Result = _oConexion.TablaConnsulta(StrBuscar);
                DataTable Datos = Result;
                DataRow row = Datos.Rows[0];
                Empresa.IdPapeleria = Convert.ToInt32(row["IdPapeleria"]);
                Empresa.NombrePape = row["NombrePape"].ToString();
                Empresa.MisionPape = row["MisionPape"].ToString();
                Empresa.VisionPape = row["VisionPape"].ToString();
                Empresa.ValoresPape = row["ValoresPape"].ToString();
                Empresa.CorreoPape = row["CorreoPape"].ToString();
                Empresa.TelefenoPape = row["TelefenoPepe"].ToString();
                Empresa.IdDireccion1 = Convert.ToInt32(row["IdDireccion1"]);
                return Empresa;
            }
            catch
            {
                return null;
            }
        }

        public List<EmpresaModel> DatosEmpresa()
        {
            try
            {
                string Query = ("Select * from Papeleria where IdPapeleria= 1");
                var Resultado = _oConexion.TablaConnsulta(Query);
                List<EmpresaModel> ListaDatosEmp = new List<EmpresaModel>();
                foreach (DataRow DatosEmpre in Resultado.Rows)
                {
                    var _oEmpresaModel = new EmpresaModel()
                    {
                        IdPapeleria = int.Parse(DatosEmpre[0].ToString()),
                        NombrePape = DatosEmpre[1].ToString(),
                        MisionPape = DatosEmpre[2].ToString(),
                        VisionPape = DatosEmpre[3].ToString(),
                        ValoresPape = DatosEmpre[4].ToString(),
                        CorreoPape = DatosEmpre[5].ToString(),
                        TelefenoPape = DatosEmpre[6].ToString(),
                        IdDireccion1 = int.Parse(DatosEmpre[7].ToString())
                    };
                    ListaDatosEmp.Add(_oEmpresaModel);
                }
                return ListaDatosEmp;

            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
