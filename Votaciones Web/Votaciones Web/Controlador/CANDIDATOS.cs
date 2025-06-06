using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votaciones_Web.Controlador
{
    public class CANDIDATOS
    {
        private int tarjeton;
        private string nombre_candidato;
        private int cantidad_votos;
        private int id_partido;

        public CANDIDATOS(int tarjeton, string nombre_candidato, int cantidad_votos, int id_partido)
        {
            this.Tarjeton = tarjeton;
            this.Nombre_candidato = nombre_candidato;
            this.Cantidad_votos = cantidad_votos;
            this.Id_partido = id_partido;
        }

        public int Tarjeton { get => tarjeton; set => tarjeton = value; }
        public string Nombre_candidato { get => nombre_candidato; set => nombre_candidato = value; }
        public int Cantidad_votos { get => cantidad_votos; set => cantidad_votos = value; }
        public int Id_partido { get => id_partido; set => id_partido = value; }
    }
}