using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ticket
    {
        public int NroTicket { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSucursal { get; set; }
        public int IdMozo { get; set; }
        public int IdUsuario { get; set; }

    }
}
