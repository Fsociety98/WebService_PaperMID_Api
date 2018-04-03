using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class MunicipioDAL
    {
        ConexionDAL _oConexionDAL;
        public MunicipioDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }

        public List<MunicipioModel> TablaMunicipios()
        {
            try
            {
                string Query = ("Select IdMunicipio,NombreMuni from Municipio where StatusMuni=1");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<MunicipioModel> Municipios = new List<MunicipioModel>();
                foreach (DataRow Municipio in Resultado.Rows)
                {
                    var _oMunicipioModel = new MunicipioModel()
                    {
                        IdMunicipio = int.Parse(Municipio[0].ToString()),
                        NombreMuni =Municipio[1].ToString()
                    };
                Municipios.Add(_oMunicipioModel);
                }
                return Municipios;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public MunicipioModel Recuperar_Muni(long IdMunicipio)
        {
            try
            {
                string Query = String.Format("Select IdMunicipio,NombreMuni from Municipio where IdMunicipio='{0}'", IdMunicipio);
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                DataTable Datos = Resultado;
                DataRow Row = Datos.Rows[0];
                var oMunicipioModel = new MunicipioModel()
                {
                    IdMunicipio = Convert.ToInt32(Row["IdMunicipio"]),
                    NombreMuni = Row["NombreMuni"].ToString()
                };
                return oMunicipioModel;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
