using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Votaciones_Web.Controlador;

namespace Votaciones_Web
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btVotar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbTarjeton.SelectedValue))
            {
                lbRealizado.Text = "Debe seleccionar un tarjeton.";
                return;
            }

            int CEDULA = Int32.Parse(cbVotante.SelectedItem.ToString());
            VOTANTES objVotantes = new VOTANTES(CEDULA, "", false);

            SqlConnection objConector1 = Db.conectar("VOTACIONES");
            string sql1 = "SELECT * FROM VOTANTES WHERE CEDULA = " + objVotantes.Cedula;
            SqlDataReader objTabla = Db.consulta(sql1, objConector1);
            if (objTabla.Read())
            {

                objVotantes.Nombre = objTabla["NOMBRE"].ToString();
                Db.cerrar(objConector1);


                SqlConnection objConector2 = Db.conectar("VOTACIONES");
                string sql2 = "Update VOTANTES set YA_VOTO = " + "'true'" + " WHERE CEDULA = " + objVotantes.Cedula;
                int fila = Db.operar(sql2, objConector2);
                if (fila > 0)
                {

                    Db.cerrar(objConector2);
                    SqlConnection objConector3 = Db.conectar("VOTACIONES");

                    String sql3 = "SELECT * FROM CANDIDATOS WHERE TARJETON = " +Int32.Parse(cbTarjeton.SelectedItem.ToString());
                    SqlDataReader objTabla1 = Db.consulta(sql3, objConector3);
                    if (objTabla1.Read())
                    {
                           

                        int tarjeton = Int32.Parse(objTabla1["TARJETON"].ToString());
                        string nombre_candidato = objTabla1["NOMBRE_CANDIDATO"].ToString();
                        int cantidad_votos = (Int32.Parse(objTabla1["CANTIDAD_VOTOS"].ToString()))+ 1;
                        int id_partido = Int32.Parse(objTabla1["ID_PARTIDO"].ToString());
                        CANDIDATOS objCandidatos = new CANDIDATOS(tarjeton,nombre_candidato,cantidad_votos,id_partido);
                        Db.cerrar(objConector3);

                        SqlConnection objConector4 = Db.conectar("VOTACIONES");
                        string sql4 = "Update CANDIDATOS set CANTIDAD_VOTOS = " + objCandidatos.Cantidad_votos + " WHERE TARJETON = " + objCandidatos.Tarjeton;
                        int fila1 = Db.operar(sql4, objConector4);
                        if (fila1 >0)
                        {
                            Db.cerrar(objConector4);
                           
                            cbVotante.ClearSelection();
                            cbVotante.DataBind();
                            btCancelar.Enabled = false;
                            btVotar.Enabled = false;
                            txNombre.Text = "";
                            string respuesta = "Voto realizado con exito";
                            lbRealizado.Text = respuesta.ToString();
                            cbTarjeton.Enabled = false;
                            cbTarjeton.ClearSelection();
                            btConsultarNombre.Enabled = true;  
                            return;
                        }

                    }

                    
                }
       


            }
        }

        protected void btConsultarNombre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVotante.SelectedValue))
            {
                lbRealizado.Text = "Debe seleccionar un votante.";
                return;
            }
            SqlConnection objconector = Db.conectar("VOTACIONES");
            if (objconector != null)
            {
                string sql = "SELECT * FROM VOTANTES WHERE CEDULA =" + Int32.Parse(cbVotante.SelectedItem.ToString()) ;
                SqlDataReader objTabla = Db.consulta(sql, objconector);

                if (objTabla.Read())
                {
                    txNombre.Text = objTabla["NOMBRE"].ToString();
                    cbTarjeton.Enabled = true;
                    btVotar.Enabled = true; 
                    btCancelar.Enabled = true;
                    lbRealizado.Text = "";
                    objTabla.Close();
                    objconector.Close();
                    btConsultarNombre.Enabled = false;
     
                
                }
          
            
            }
    }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            btCancelar.Enabled = false;
            btVotar.Enabled=false;
            txNombre.Text = "";
            cbVotante.ClearSelection();
            btConsultarNombre.Enabled = true;
        }

        protected void cbTarjeton_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
