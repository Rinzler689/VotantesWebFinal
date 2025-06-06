using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Votaciones_Web
{
    public class Db
    {
        public static SqlConnection conectar(string nomBD)
        {
            SqlConnection conectar = new SqlConnection("Data Source=KEVIN-PC\\SQLEXPRESS;Initial Catalog=" + nomBD + ";Integrated Security=SSPI;");

            try
            {
                conectar.Open();
                return conectar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexión " + ex.ToString()); return null;
            }
        }
        public static SqlDataReader consulta(string conSQL, SqlConnection conector)
        {
            try
            {
                SqlCommand comando = new SqlCommand(conSQL, conector);
                SqlDataReader tabla = comando.ExecuteReader(); return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la consulta " + ex.ToString()); return null;
            }
        }
        public static int operar(string conSQL, SqlConnection conector)
        {
            int num = 0;
            try
            {
                SqlCommand comando = new SqlCommand(conSQL, conector);
                num = comando.ExecuteNonQuery(); return num;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Fallo la consulta" + e.ToString()); return num;
            }
        }
        public static void cerrar(SqlConnection conector)
        {
            try
            {
                conector.Close();
            }
            catch (SqlException eq) { }
        }
    }
}