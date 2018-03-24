using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebService_PaperMID_Api.Models;

namespace WebService_PaperMID_Api.DAL
{
    public class ProductoDAL
    {
        ConexionDAL _oConexion;
        public ProductoDAL()
        {
            _oConexion = new ConexionDAL();
        }
        public int Agregar(object Obj)
        {
            ProductoModel _oModel = (ProductoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Agregar_Producto @CódigoProd, @NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1")
            {
                CommandType = CommandType.Text
            };
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = _oModel.CódigoProd;
            Cmd.Parameters.Add("@NombreProd", SqlDbType.VarChar).Value = _oModel.NombreProd;
            Cmd.Parameters.Add("@DescripcionProd", SqlDbType.VarChar).Value = _oModel.DescripcionProd;
            Cmd.Parameters.Add("@PrecioProd", SqlDbType.Float).Value = _oModel.PrecioProd;
            Cmd.Parameters.Add("@DescuentoProd", SqlDbType.Float).Value = _oModel.DescuentoProd;
            Cmd.Parameters.Add("@CantidadDisponibleProd", SqlDbType.Int).Value = _oModel.CantidadDisponibleProd;
            Cmd.Parameters.Add("@CantidadMinimaProd", SqlDbType.Int).Value = _oModel.CantidadMinimaProd;
            Cmd.Parameters.Add("@IdTipoProducto1", SqlDbType.Int).Value = _oModel.IdTipoProducto1;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oModel.IdProveedor1;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public int Eliminar(object Obj)
        {
            SqlCommand Cmd = new SqlCommand("EXEC SP_Eliminar_Producto @IdProducto");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.VarChar).Value = Obj;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);

        }

        public int Modificar(object Obj)
        {
            ProductoModel _oModel = (ProductoModel)Obj;
            SqlCommand Cmd = new SqlCommand("EXEC SP_Modificar_Producto @IdProducto,@CódigoProd,@NombreProd,@DescripcionProd,@PrecioProd,@DescuentoProd,@CantidadDisponibleProd,@CantidadMinimaProd,@IdTipoProducto1,@IdProveedor1");
            Cmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = _oModel.IdProducto;
            Cmd.Parameters.Add("@CódigoProd", SqlDbType.VarChar).Value = _oModel.CódigoProd;
            Cmd.Parameters.Add("@NombreProd", SqlDbType.VarChar).Value = _oModel.NombreProd;
            Cmd.Parameters.Add("@DescripcionProd", SqlDbType.VarChar).Value = _oModel.DescripcionProd;
            Cmd.Parameters.Add("@PrecioProd", SqlDbType.Float).Value = _oModel.PrecioProd;
            Cmd.Parameters.Add("@DescuentoProd", SqlDbType.Float).Value = _oModel.DescuentoProd;
            Cmd.Parameters.Add("@CantidadDisponibleProd", SqlDbType.Int).Value = _oModel.CantidadDisponibleProd;
            Cmd.Parameters.Add("@CantidadMinimaProd", SqlDbType.Int).Value = _oModel.CantidadMinimaProd;
            Cmd.Parameters.Add("@IdTipoProducto1", SqlDbType.Int).Value = _oModel.IdTipoProducto1;
            Cmd.Parameters.Add("@IdProveedor1", SqlDbType.Int).Value = _oModel.IdProveedor1;
            Cmd.CommandType = CommandType.Text;
            return _oConexion.EjecutarSQL(Cmd);
        }

        public List<ProductoModel> Lista_Producto()
        {
            try
            {
                string Query = ("SELECT * FROM Vst_Lista_Producto");
                var Resultado = _oConexion.TablaConnsulta(Query);
                List<ProductoModel> ListProductos = new List<ProductoModel>();
                foreach (DataRow Producto in Resultado.Rows)
                {
                    var oProductoModel = new ProductoModel()
                    {
                        IdProducto = int.Parse(Producto[0].ToString()),
                        CódigoProd = Producto[1].ToString(),
                        NombreProd = Producto[2].ToString(),
                        DescripcionProd= Producto[3].ToString(),
                        PrecioProd = Convert.ToDouble(Producto[4].ToString()),
                        DescuentoProd = Convert.ToDouble(Producto[5].ToString()),
                        CantidadDisponibleProd=int.Parse(Producto[6].ToString()),
                        CantidadMinimaProd=int.Parse(Producto[7].ToString()),
                        IdTipoProducto1=int.Parse(Producto[8].ToString()),
                        IdProveedor1 =int.Parse(Producto[9].ToString())
                    };
                    ListProductos.Add(oProductoModel);
                }
                return ListProductos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<ProductoModel> Top4()
        {
            try
            {
                string Query = ("SELECT Top 4 * FROM Vst_Lista_Producto order by IdProducto Desc");
                var Resultado = _oConexion.TablaConnsulta(Query);
                List<ProductoModel> ListProductos = new List<ProductoModel>();
                foreach (DataRow Producto in Resultado.Rows)
                {
                    var oProductoModel = new ProductoModel()
                    {
                        IdProducto = int.Parse(Producto[0].ToString()),
                        CódigoProd = Producto[1].ToString(),
                        NombreProd = Producto[2].ToString(),
                        DescripcionProd = Producto[3].ToString(),
                        PrecioProd = Convert.ToDouble(Producto[4].ToString()),
                        DescuentoProd = Convert.ToDouble(Producto[5].ToString()),
                        CantidadDisponibleProd = int.Parse(Producto[6].ToString()),
                        CantidadMinimaProd = int.Parse(Producto[7].ToString()),
                        IdTipoProducto1 = int.Parse(Producto[8].ToString()),
                        IdProveedor1 = int.Parse(Producto[9].ToString())
                    };
                    ListProductos.Add(oProductoModel);
                }
                return ListProductos;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public ProductoModel RecuperarProducto(long IdProducto)
        {
            try
            {
                var _Producto = new ProductoModel();
                DataTable Datos = _oConexion.TablaConnsulta(String.Format("SELECT * FROM Vst_Lista_Producto WHERE IdProducto='{0}'", IdProducto));
                DataRow Row = Datos.Rows[0];
                _Producto.IdProducto = Convert.ToInt32(Row["IdProducto"]);
                _Producto.CódigoProd = Row["CódigoProd"].ToString();
                _Producto.NombreProd = Row["NombreProd"].ToString();
                _Producto.DescripcionProd = Row["DescripcionProd"].ToString();
                _Producto.PrecioProd = Convert.ToDouble(Row["PrecioProd"]);
                _Producto.DescuentoProd = Convert.ToDouble(Row["DescuentoProd"]);
                _Producto.CantidadDisponibleProd = Convert.ToInt32(Row["CantidadDisponibleProd"]);
                _Producto.CantidadMinimaProd = Convert.ToInt32(Row["CantidadMinimaProd"]);
                _Producto.IdTipoProducto1 = Convert.ToInt32(Row["IdTipoProducto1"]);
                _Producto.IdProveedor1 = Convert.ToInt32(Row["IdProveedor1"]);
                return _Producto;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
