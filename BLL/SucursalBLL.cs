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
    public class SucursalBLL
    {
        //SucursalDAL sucursalDAL = new SucursalDAL();
        public static bool InsertarSucursal(Sucursal sucursal)
        {
            return DAL.SucursalDAL.InsertarSucursal(sucursal);
        }
        public static DataTable CargarGV()
        {
            return DAL.SucursalDAL.CargarGV();
        }
        public static DataTable ObtenerTipoIva()
        {
            return DAL.SucursalDAL.ObtenerTipoIva();
        }
    }
}
