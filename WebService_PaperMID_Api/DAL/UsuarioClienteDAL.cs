using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class UsuarioClienteDAL
    {
        ConexionDAL _oConexionDAL;
        public UsuarioClienteDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }
        public List<UsuarioClienteModel> TablaDatosUsuario()
        {
            try
            {
                string Query = ("Select * from Usuario inner join Direccion on IdDireccion=IdDireccion2 inner join DireccionFiscal on IdDireccionFiscal=IdDireccionFiscal1");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<UsuarioClienteModel> UsuarioCliente = new List<UsuarioClienteModel>();
                foreach (DataRow Cliente in Resultado.Rows)
                {
                    var _oUsuarioClienteModel = new UsuarioClienteModel()
                    {
                        IdUsuario = int.Parse(Cliente[0].ToString()),
                        Usuario = Cliente[1].ToString(),
                        ContraseñaUsu = Cliente[2].ToString(),
                        NombreUsu = Cliente[3].ToString(),
                        ApellidoPaternoUsu = Cliente[4].ToString(),
                        ApellidoMaternoUsu = Cliente[5].ToString(),
                        RFCUsu = Cliente[6].ToString(),
                        RazonSocioUsu = Cliente[7].ToString(),
                        TelefonoUsu = Cliente[8].ToString(),
                        CorreoUsu = Cliente[9].ToString(),
                        IdDireccion2 = int.Parse(Cliente[12].ToString()),
                        IdDireccionFiscalUser = int.Parse(Cliente[14].ToString()),
                        IdDireccion = int.Parse(Cliente[15].ToString()),
                        CalleDir = Cliente[16].ToString(),
                        NumInteDir = Cliente[17].ToString(),
                        NumExteDir = Cliente[18].ToString(),
                        CruzaDir = Cliente[19].ToString(),
                        ColoniaDir = Cliente[20].ToString(),
                        CPDir = Cliente[21].ToString(),
                        IdMunicipio1 = int.Parse(Cliente[25].ToString()),
                        Completo = Cliente[28].ToString(),
                        IdDireccionFiscal = int.Parse(Cliente[29].ToString()),
                        CalleDirFis = Cliente[30].ToString(),
                        NumInteDirFis = Cliente[31].ToString(),
                        NumExteDirFis = Cliente[32].ToString(),
                        CruzaDirFis = Cliente[33].ToString(),
                        ColoniaDirFis = Cliente[34].ToString(),
                        CPDirFis = Cliente[35].ToString(),
                        IdMunicipio4 = int.Parse(Cliente[39].ToString()),
                        CompletoDirFis = Cliente[42].ToString()
                    };
                    UsuarioCliente.Add(_oUsuarioClienteModel);
                }
                return UsuarioCliente;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<UsuarioClienteModel> TablaDatosUsuarioPost(string id)
        {
            try
            {
                string Query = ("Select * from Usuario inner join Direccion on IdDireccion=IdDireccion2 inner join DireccionFiscal on IdDireccionFiscal=IdDireccionFiscal1 where IdUsuario="+id);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<UsuarioClienteModel> UsuarioCliente = new List<UsuarioClienteModel>();
                foreach (DataRow Cliente in Resultado.Rows)
                {
                    var _oUsuarioClienteModel = new UsuarioClienteModel()
                    {
                        IdUsuario = int.Parse(Cliente[0].ToString()),
                        Usuario = Cliente[1].ToString(),
                        ContraseñaUsu = Cliente[2].ToString(),
                        NombreUsu = Cliente[3].ToString(),
                        ApellidoPaternoUsu = Cliente[4].ToString(),
                        ApellidoMaternoUsu = Cliente[5].ToString(),
                        RFCUsu = Cliente[6].ToString(),
                        RazonSocioUsu=Cliente[7].ToString(),
                        TelefonoUsu=Cliente[8].ToString(),
                        CorreoUsu=Cliente[9].ToString(),
                        IdDireccion2=int.Parse(Cliente[12].ToString()),
                        IdDireccionFiscalUser=int.Parse(Cliente[14].ToString()),
                        IdDireccion=int.Parse(Cliente[15].ToString()),
                        CalleDir=Cliente[16].ToString(),
                        NumInteDir=Cliente[17].ToString(),
                        NumExteDir=Cliente[18].ToString(),
                        CruzaDir=Cliente[19].ToString(),
                        ColoniaDir=Cliente[20].ToString(),
                        CPDir=Cliente[21].ToString(),
                        IdMunicipio1=int.Parse(Cliente[25].ToString()),
                        Completo=Cliente[28].ToString(),
                        IdDireccionFiscal=int.Parse(Cliente[29].ToString()),
                        CalleDirFis=Cliente[30].ToString(),
                        NumInteDirFis=Cliente[31].ToString(),
                        NumExteDirFis=Cliente[32].ToString(),
                        CruzaDirFis=Cliente[33].ToString(),
                        ColoniaDirFis=Cliente[34].ToString(),
                        CPDirFis=Cliente[35].ToString(),
                        IdMunicipio4=int.Parse(Cliente[39].ToString()),
                        CompletoDirFis=Cliente[42].ToString()
                    };
                    UsuarioCliente.Add(_oUsuarioClienteModel);
                }
                return UsuarioCliente;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public UsuarioClienteModel Recuperar_UsuarioCliente(long IdUsuario)
        {
            try
            {
                string Query = String.Format("Select * from Usuario inner join Direccion on IdDireccion=IdDireccion2 inner join DireccionFiscal on IdDireccionFiscal=IdDireccionFiscal1 where IdUsuario='{0}'", IdUsuario);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                var oUsuarioClienteModel = new UsuarioClienteModel()
                {
                    IdUsuario = int.Parse(Row["IdUsuario"].ToString()),
                    Usuario = Row["Usuario"].ToString(),
                    ContraseñaUsu = Row["ContraseñaUsu"].ToString(),
                    NombreUsu = Row["NombreUsu"].ToString(),
                    ApellidoPaternoUsu = Row["ApellidoPaternoUsu"].ToString(),
                    ApellidoMaternoUsu = Row["ApellidoMaternoUsu"].ToString(),
                    RFCUsu = Row["RFCUsu"].ToString(),
                    RazonSocioUsu = Row["RazonSocialUsu"].ToString(),
                    TelefonoUsu = Row["TelefonoUsu"].ToString(),
                    CorreoUsu = Row["CorreoUsu"].ToString(),
                    IdDireccion2 = int.Parse(Row["IdDireccion2"].ToString()),
                    IdDireccionFiscalUser = int.Parse(Row["IdDireccionFiscal"].ToString()),
                    IdDireccion = int.Parse(Row["IdDireccion"].ToString()),
                    CalleDir = Row["CalleDir"].ToString(),
                    NumInteDir = Row["NumInteDir"].ToString(),
                    NumExteDir = Row["NumExteDir"].ToString(),
                    CruzaDir = Row["CruzaDir"].ToString(),
                    ColoniaDir = Row["ColoniaDir"].ToString(),
                    CPDir = Row["CPDir"].ToString(),
                    IdMunicipio1 = int.Parse(Row["IdMunicipio1"].ToString()),
                    Completo = Row["Completo"].ToString(),
                    IdDireccionFiscal = int.Parse(Row["IdDireccionFiscal"].ToString()),
                    CalleDirFis = Row["CalleDirFis"].ToString(),
                    NumInteDirFis = Row["NumInteDirFis"].ToString(),
                    NumExteDirFis = Row["NumExteDirFis"].ToString(),
                    CruzaDirFis = Row["CruzaDirFis"].ToString(),
                    ColoniaDirFis = Row["ColoniaDirFis"].ToString(),
                    CPDirFis = Row["CPDirFis"].ToString(),
                    IdMunicipio4 = int.Parse(Row["IdMunicipio4"].ToString()),
                    CompletoDirFis = Row["CompletoDisFis"].ToString()
                };
                return oUsuarioClienteModel;
            }
            catch (Exception)
            {

                return null;
            }
        }





    }
}
