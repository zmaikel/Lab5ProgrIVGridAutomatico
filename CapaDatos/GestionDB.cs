using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CapaDatos
{
    public class GestionDB
    {
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionPruebas"].ConnectionString;

        public DataTable cargaCarro()
        {
            DataTable objTabla = new DataTable(); 
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = CommandType.Text;
            comando.CommandText = "Select * from T_Carro";
            comando.Connection = conexion;
            SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando);
            sqlAdaptador.Fill(objTabla);
            return objTabla;
        }
        public int registrarCarro(CapaDatos.Entidades.Carro objCarro)
        {
            int cantidadRegistros = -1;

            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into T_Carro (Marca,Modelo,Pais,Costo) Values (@Marca,@Modelo,@Pais,@Costo)";
                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            return cantidadRegistros;




        }
        public int actualizarCarro(CapaDatos.Entidades.Carro objCarro)
        {
            int cantidadRegistros = -1;

            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update T_Carro " +
                                  "set Marca = @Marca, " +
                                  "    Modelo = @Modelo, " +
                                  "    Pais = @Pais, " +
                                  "    Costo = @Costo " +
                                  "Where IdCarro = @IdCarro ";

                cmd.Parameters.Add(new SqlParameter("@Marca", objCarro.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", objCarro.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Pais", objCarro.Pais));
                cmd.Parameters.Add(new SqlParameter("@Costo", objCarro.Costo));
                cmd.Parameters.Add(new SqlParameter("@IdCarro", objCarro.IdCarro));
                cantidadRegistros = cmd.ExecuteNonQuery(); 
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
        public int eliminarPersona(CapaDatos.Entidades.Carro objCarro)
        {
            int cantidadRegistros = -1;

            using (SqlConnection sqlCon = new SqlConnection(cadenaConexion))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from T_Carro Where IdCarro = @IdCarro";
                cmd.Parameters.Add(new SqlParameter("@IdCarro", objCarro.IdCarro));
                sqlCon.Open();
                cantidadRegistros = cmd.ExecuteNonQuery(); 
                sqlCon.Close();
            }

            return cantidadRegistros;
        }
    }

}
