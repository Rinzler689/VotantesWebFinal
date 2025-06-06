using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VotacionesWebControlador.Entidades
{
    public class Votante
    {
        [Key]
        public int Cedula { get; set; } //Campo obligatorio, es la clave primaria por defecto
        public string Nombre { get; set; } = string.Empty;
        public bool Ya_voto { get; set; } 
        

    }
}
