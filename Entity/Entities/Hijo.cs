using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Hijo
    {
        public int IdDerHab { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FchNac { get; set; }
        public bool Estado { get; set; }
        public Personal Padre { get; set; }
    }
}
