using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
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
        public static DataTable ObtenerArticulos()
        {
            return DAL.TicketDAL.ObtenerArticulos();
        }
        public static DataTable ObtenerMozos()
        {
            return DAL.TicketDAL.ObtenerMozos();
        }
        public static Articulo SeleccionarIDArticulo(int a)
        {
            return DAL.TicketDAL.SeleccionarIDArticulo(a);
        }
    }
}
