using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL
    {
        public static int InsertarTicket(Ticket t)
        {
            return DAL.TicketDAL.InsertarTicket(t);
        }
        public static bool InsertarDetalleTicket(Detalle_Ticket d)
        {
            return DAL.TicketDAL.InsertarDetalleTicket(d);
        }
    }
}
