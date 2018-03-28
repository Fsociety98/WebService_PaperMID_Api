using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebService_PaperMID_Api.DAL
{
    public class ConexionDAL
    {
        SqlConnection Con;
        SqlCommand Cmd;
        SqlDataAdapter Adaptador;
        DataTable TablaVirtual;
        DataSet DAtaSetAdaptador;
        //String Servidor = "Data Source=sql7004.site4now.net;Initial Catalog=DB_A36000_PaperMIDPrueba;User ID=DB_A36000_PaperMIDPrueba_admin; password=PaperMID123;";
        //String Heredia = "Data Source=DESKTOP-8BM8OCF; Initial Catalog=PaperMID; Integrated Security=True";
        //String Uicab = "Data Source=DESKTOP-891638V;Initial Catalog=PaperMID;Integrated Security=True";
        String Server = "Data Source=SQL7004.site4now.net;Initial Catalog=DB_A386B8_PaperMID;User Id=DB_A386B8_PaperMID_admin;Password=Cs18191819;";

        public SqlConnection EstablecerConexion()
        {
<<<<<<< HEAD
            Con = new SqlConnection(Heredia);
=======
            Con = new SqlConnection(Server);
>>>>>>> adb523dc6859dc050f3ccb49a1eb0581407feb2b
            return Con;
        }

        public void AbrirConexion()
        {
            Con.Open();
        }

        public void CerrarConexion()
        {
            Con.Close();
        }

        public int EjecutarSQL(string Sentencia)
        {
            try
            {
                Cmd = new SqlCommand();
                Cmd.Connection = EstablecerConexion();
                AbrirConexion();
                Cmd.CommandText = Sentencia;
                int Confirmacion = Cmd.ExecuteNonQuery();
                CerrarConexion();
                return 1;
            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public int EjecutarSQL(SqlCommand SqlComando)
        {
            Cmd = new SqlCommand();
            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            int id = 0; id = Convert.ToInt32(Cmd.ExecuteScalar());
            this.CerrarConexion();
            return id;
        }

        public DataTable TablaConnsulta(string Sentencia)
        {
            Adaptador = new SqlDataAdapter(Sentencia, EstablecerConexion());
            TablaVirtual = new DataTable();

            //Rellenar un objeto DataSet con los resultados del elemento SelectCommand.
            Adaptador.Fill(TablaVirtual);
            return TablaVirtual;
        }


        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }

        public DataSet EjecutarSentencia_string(string SqlComando)
        {

            // SELECT (Devolver registros)
            Adaptador = new SqlDataAdapter();
            Cmd = new SqlCommand();
            DAtaSetAdaptador = new DataSet();

            Cmd.CommandText = SqlComando;
            Cmd.Connection = this.EstablecerConexion();
            this.AbrirConexion();
            Adaptador.SelectCommand = Cmd;
            Adaptador.Fill(DAtaSetAdaptador);
            this.CerrarConexion();
            return DAtaSetAdaptador;

        }
    }
}
