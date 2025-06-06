using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Votaciones_Web.Controlador;

namespace Votaciones_Web
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
   

        protected void btFinalizarElecciones_Click(object sender, EventArgs e)
        {
            int totalVotos = 0;
            double mitadVotos = 0;


            SqlConnection objConector = Db.conectar("VOTACIONES");
            string sql = "SELECT SUM(CANTIDAD_VOTOS) AS TOTAL_VOTOS FROM CANDIDATOS";
            SqlDataReader objTabla = Db.consulta(sql, objConector);
            if (objTabla.Read())
            {
                totalVotos = Int32.Parse(objTabla["TOTAL_VOTOS"].ToString());
                Db.cerrar(objConector);
            }

            if (totalVotos > 0)
            {
                mitadVotos = totalVotos / 2;
                SqlConnection objConector1 = Db.conectar("VOTACIONES");
                string sql1 = "SELECT C.NOMBRE_CANDIDATO AS 'NOMBRE DEL CANDIDATO', C.TARJETON AS 'TARJETON', P.NOMBRE_PARTIDO AS 'NOMBRE DEL PARTIDO', C.CANTIDAD_VOTOS AS 'CANTIDAD DE VOTOS' FROM CANDIDATOS C JOIN PARTIDOS P ON C.ID_PARTIDO = P.ID_PARTIDO ORDER BY C.CANTIDAD_VOTOS DESC";
                SqlDataReader objTabla1 = Db.consulta(sql1, objConector1);
                while (objTabla1.Read())
                {

                    string nombre = objTabla1["NOMBRE DEL CANDIDATO"].ToString();
                    string tarjeton = objTabla1["TARJETON"].ToString();
                    string partido = objTabla1["NOMBRE DEL PARTIDO"].ToString();
                    int votos = Int32.Parse(objTabla1["CANTIDAD DE VOTOS"].ToString());
                    if (votos>= mitadVotos +1)
                    {
                        lbGanador.Text = "El ganador es:<br />" + "• " + nombre + " (Tarjetón: " + tarjeton + ") (" + partido + ") con " + votos + " votos<br />";
                        lbGanador.Visible = true;
                        Db.cerrar(objConector1);
                        btFinalizarElecciones.Enabled = false;
                        lbConteoCandidato.Visible = true;
                        lbConteoPartido.Visible = true;
                        gvVotosCandidato.Visible = true;
                        gvVotosPartido.Visible = true;
                        return;
                    }
                  
                }
                Db.cerrar(objConector1);
                SqlConnection objConector2 = Db.conectar("VOTACIONES");
                string sql2 = "SELECT TOP 2  C.NOMBRE_CANDIDATO AS 'NOMBRE DEL CANDIDATO', P.NOMBRE_PARTIDO AS 'NOMBRE DEL PARTIDO',  C.CANTIDAD_VOTOS AS 'CANTIDAD DE VOTOS',C.TARJETON AS 'TARJETON' FROM CANDIDATOS C JOIN PARTIDOS P ON C.ID_PARTIDO = P.ID_PARTIDO ORDER BY C.CANTIDAD_VOTOS DESC";
                SqlDataReader objTabla2 = Db.consulta(sql2, objConector2);
                string mensaje = "Habrá segunda vuelta entre:<br />";
                while (objTabla2.Read())
                {
                    string nombre = objTabla2["NOMBRE DEL CANDIDATO"].ToString();
                    string partido = objTabla2["NOMBRE DEL PARTIDO"].ToString();
                    int votos = Int32.Parse(objTabla2["CANTIDAD DE VOTOS"].ToString());
                    string tarjeton = objTabla2["TARJETON"].ToString();
                    mensaje += "• " + nombre + " (Tarjetón: " + tarjeton + ") (" + partido + ") con " + votos + " votos<br />";
                }
                lbGanador.Text = mensaje;
                lbGanador.Visible = true;

                Db.cerrar(objConector2);

            }
            else
            {
                lbAlerta.Visible = true;
                lbAlerta.Text = "No ha votado nadie."; 
                return;
            }
            btFinalizarElecciones.Enabled = false;
            lbConteoCandidato.Visible = true;
            lbConteoPartido.Visible = true;
            gvVotosCandidato.Visible = true;
            gvVotosPartido.Visible = true;

        }
    }
}