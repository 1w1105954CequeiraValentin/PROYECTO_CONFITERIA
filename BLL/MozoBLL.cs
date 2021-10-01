using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MozoBLL
    {
        
        public static bool InsertarMozo(Mozo mozo)
        {
            return DAL.MozoDAL.InsertarMozo(mozo);
        }
        public static bool ModificarMozo(Mozo mozo1)
        {
            return DAL.MozoDAL.ModificarMozo(mozo1);
        }
        public static bool EliminarMozo(Mozo mozo2)
        {
            return DAL.MozoDAL.EliminarMozo(mozo2);
        }
        public static DataTable CargarGVMozos()
        {
            return DAL.MozoDAL.CargarGVMozos();
        }
        public static Mozo SeleccionarIDMozo(int m)
        {
            return DAL.MozoDAL.SeleccionarIDMozo(m);
        }
    }
}
