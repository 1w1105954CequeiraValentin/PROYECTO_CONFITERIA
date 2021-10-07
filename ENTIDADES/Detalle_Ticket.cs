using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Detalle_Ticket
    {
        public int NroDetalle { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public int NroTicket { get; set; }
        public int IdArticulo { get; set; }

    }
}
