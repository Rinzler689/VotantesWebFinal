using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votaciones_Web
{
    public class VOTANTES
    {

        private int cedula;
        private string nombre;
        private bool ya_voto;

        public VOTANTES(int cedula, string nombre, bool ya_voto)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Ya_voto = ya_voto;

        }

        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public bool Ya_voto { get => ya_voto; set => ya_voto = value; }
    }

}