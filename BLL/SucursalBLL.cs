using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SucursalBLL
    {
        SucursalDAL sucursalDAL = new SucursalDAL();
        public bool InsertarSucursal(Sucursal sucursal)
        {
            return sucursalDAL.InsertarSucursal(sucursal);
        }
    }
}
