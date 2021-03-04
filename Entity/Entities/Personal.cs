using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Entities
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FchNac { get; set; }
        public DateTime FchIngreso { get; set; }
        public bool Estado { get; set; }
        public IEnumerable<Hijo> Hijos { get; set; }
    }
}
