using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MozoBLL
    {
        MozoDAL mozoDAL = new MozoDAL();
        public bool InsertarMozo(Mozo mozo)
        {
            return mozoDAL.InsertarMozo(mozo);
        }
        public bool ModificarMozo(Mozo mozo1)
        {
            return mozoDAL.ModificarMozo(mozo1);
        }
        public bool EliminarMozo(Mozo mozo2)
        {
            return mozoDAL.EliminarMozo(mozo2);
        }
    }
}
