using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Mozo
    {
        public int IdMozo { get; set; }
        public int NroDoc { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public float Comision { get; set; }
        public DateTime FechaIngreso { get; set; }

    }
}
