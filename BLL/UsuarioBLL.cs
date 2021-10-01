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
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        public static bool InsertarUsuario(Usuario usuario)
        {
            return DAL.UsuarioDAL.InsertarUsuario(usuario);
        }
        public static bool ModificarUsuario(Usuario usuario1)
        {
            return DAL.UsuarioDAL.ModificarUsuario(usuario1);
        }
        public static bool EliminarUsuario(int u)
        {
            return DAL.UsuarioDAL.EliminarUsuario(u);
        }
        public static List<Usuario> ListaUsuario(string usuario, string pass)
        {
            return DAL.UsuarioDAL.ListaUsuario(usuario, pass);
        }
        public static DataTable CargarGVUsuario()
        {
            return DAL.UsuarioDAL.CargarGVUsuario();
        }
        public static DataTable ObtenerRolUsuario()
        {
            return DAL.UsuarioDAL.ObtenerRolUsuario();
        }
        public static Usuario SeleccionarIDUsuario(int u)
        {
            return DAL.UsuarioDAL.SeleccionarIDUsuario(u);
        }
    }
}
