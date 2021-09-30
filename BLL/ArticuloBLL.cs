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
    public class ArticuloBLL
    {
        public static bool InsertarArticulo(Articulo articulo)
        {
            return DAL.ArticuloDAL.InsertarArticulo(articulo);
        }
        public static bool ModificarArticulo(Articulo articulo1)
        {
            return DAL.ArticuloDAL.ModificarArticulo(articulo1);
        }
        public static bool EliminarArticulo(int id)
        {
            return DAL.ArticuloDAL.EliminarArticulo(id);
        }
        public static List<Articulo> LstArticulos(int id)
        {
            return DAL.ArticuloDAL.LstArticulos(id);
        }
        public static Articulo SeleccionarIDArticulo(int a)
        {
            return DAL.ArticuloDAL.SeleccionarIDArticulo(a);
        }
        public static DataTable CargarGV()
        {
            return DAL.ArticuloDAL.CargarGV();
        }
        public static DataTable ObtenerRubroArticulo()
        {
            return DAL.ArticuloDAL.ObtenerRubroArticulo();
        }
    }
}
