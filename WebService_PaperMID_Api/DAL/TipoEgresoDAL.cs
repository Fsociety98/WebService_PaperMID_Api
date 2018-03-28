using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class TipoEgresoDAL
    {
        ConexionDAL _oConexionDAL;
        public TipoEgresoDAL()
        {
            _oConexionDAL = new ConexionDAL();
        }

        public List<TipoEgresoModel> TablaTipoEgreso()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_TipoEgreso");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<TipoEgresoModel> LstTipoEgreso = new List<TipoEgresoModel>();
                foreach (DataRow TipoEgreso in Resultado.Rows)
                {
                    var _oTipoIngresoModel = new TipoEgresoModel()
                    {
                        IdTipoEgreso = int.Parse(TipoEgreso[0].ToString()),
                        TipoEgreso = TipoEgreso[1].ToString()
                    };
                    LstTipoEgreso.Add(_oTipoIngresoModel);
                }
                return LstTipoEgreso;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
