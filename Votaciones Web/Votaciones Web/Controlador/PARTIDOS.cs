using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votaciones_Web.Controlador
{
    public class PARTIDOS
    {
        private int id_partido;
        private string nombre_partido;

        public PARTIDOS(int id_partido, string nombre_partido)
        {
            this.Id_partido = id_partido;
            this.Nombre_partido = nombre_partido;
        }

        public int Id_partido { get => id_partido; set => id_partido = value; }
        public string Nombre_partido { get => nombre_partido; set => nombre_partido = value; }
    }
}