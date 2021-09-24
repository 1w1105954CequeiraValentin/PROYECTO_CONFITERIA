using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArticuloBLL
    {
        ArticuloDAL articuloDAL = new ArticuloDAL();
        public bool InsertarArticulo(Articulo articulo)
        {
            return articuloDAL.InsertarArticulo(articulo);
        }
        public bool ModificarArticulo(Articulo articulo1)
        {
            return articuloDAL.ModificarArticulo(articulo1);
        }
        public bool EliminarArticulo(Articulo articulo2)
        {
            return articuloDAL.EliminarArticulo(articulo2);
        }
    }
}
