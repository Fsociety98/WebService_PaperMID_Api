using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class TipoIngresoDAL
    {
        ConexionDAL _oConexionDAL;
        public TipoIngresoDAL() {
            _oConexionDAL = new ConexionDAL();
        }

        public List<TipoIngresoModel> TablaTipoIngreso()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_TipoIngreso");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<TipoIngresoModel> LstTipoIngreso = new List<TipoIngresoModel>();
                foreach (DataRow TipoIngreso in Resultado.Rows)
                {
                    var _oTipoIngresoModel = new TipoIngresoModel()
                    {
                        IdTipoIngreso = int.Parse(TipoIngreso[0].ToString()),
                        TipoIngreso = TipoIngreso[1].ToString()
                    };
                    LstTipoIngreso.Add(_oTipoIngresoModel);
                }
                return LstTipoIngreso;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
