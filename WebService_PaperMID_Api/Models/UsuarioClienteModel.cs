using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.Models
{
    public class UsuarioClienteModel
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string ContraseñaUsu { get; set; }
        public string NombreUsu { get; set; }
        public string ApellidoPaternoUsu { get; set; }
        public string ApellidoMaternoUsu { get; set; }
        public string RFCUsu { get; set; }
        public string RazonSocioUsu { get; set; }
        public string TelefonoUsu { get; set; }
        public string CorreoUsu { get; set; }
        public int IdTipoUsuario1 { get; set; }
        public int IdDireccion2 { get; set; }
        public int IdDireccionFiscalUser { get; set; }
        //Datos de la Direccion de entrega
        public int IdDireccion { get; set; }
        public string CalleDir { get; set; }
        public string NumInteDir { get; set; }
        public string NumExteDir { get; set; }
        public string CruzaDir { get; set; }
        public string ColoniaDir { get; set; }
        public string CPDir { get; set; }
        public string UbicacionDir { get; set; }
        public string LatitudDir { get; set; }
        public string LongitudDir { get; set; }
        public int IdMunicipio1 { get; set; }
        public string Completo { get; set; }
        //Datos de la Direccion de Facturacion
        public int IdDireccionFiscal { get; set; }
        public string CalleDirFis { get; set; }
        public string NumInteDirFis { get; set; }
        public string NumExteDirFis { get; set; }
        public string CruzaDirFis { get; set; }
        public string ColoniaDirFis { get; set; }
        public string CPDirFis { get; set; }
        public string UbicacionDirFis { get; set; }
        public string LatitudDirFis { get; set; }
        public string LongitudDirFis { get; set; }
        public int IdMunicipio4 { get; set; }
        public string CompletoDirFis { get; set; }
    }
}
