using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class TipoUsuarioDAL
    {
        ConexionDAL _oConexionDAL;
        public TipoUsuarioDAL() { _oConexionDAL = new ConexionDAL(); }

        public List<TipoUsuarioModel> TablaTipoUsuario()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_TipoUsuario");
                var Resultado = _oConexionDAL.TablaConnsulta(Query);
                List<TipoUsuarioModel> TipoUsuario = new List<TipoUsuarioModel>();
                foreach (DataRow TUsuario in Resultado.Rows)
                {
                    var _oTipoUsuarioModel = new TipoUsuarioModel()
                    {
                        IdTipoUsuario = int.Parse(TUsuario[0].ToString()),
                        TipoUsu = TUsuario[1].ToString(),
                        FechaRegistroTuser = Convert.ToDateTime(TUsuario[2].ToString()),
                        StatusTuser = Convert.ToBoolean(TUsuario[3].ToString())
                    };
                    TipoUsuario.Add(_oTipoUsuarioModel);
                }
                return TipoUsuario;

            }
            catch (Exception)
            {

                return null;
            }
        }
        public TipoUsuarioModel RecuperarTipo(long IdTipoUsuario)
        {
            try
            {
                var tUser = new TipoUsuarioModel();
                string BuscarTipo = string.Format("SELECT * FROM Vst_Lista_TipoUsuario WHERE IdTipoUsuario='{0}'", IdTipoUsuario);
                DataTable Datos = _oConexionDAL.TablaConnsulta(BuscarTipo);
                DataRow Row = Datos.Rows[0];
                tUser.IdTipoUsuario = Convert.ToInt32(Row["IdTipoUsuario"]);
                tUser.TipoUsu = Row["TipoUsu"].ToString();
                tUser.FechaRegistroTuser = Convert.ToDateTime(Row["FechaRegistroTuser"].ToString());
                tUser.StatusTuser = Convert.ToBoolean(Row["StatusTuser"].ToString());
                return tUser;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
