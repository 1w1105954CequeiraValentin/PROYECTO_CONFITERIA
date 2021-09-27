using DAL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        UsuarioDAL usuarioDAL = new UsuarioDAL();
        public bool InsertarUsuario(Usuario usuario)
        {
            return usuarioDAL.InsertarUsuario(usuario);
        }
        public bool ModificarUsuario(Usuario usuario1)
        {
            return usuarioDAL.ModificarUsuario(usuario1);
        }
        public bool EliminarUsuario(Usuario usuario2)
        {
            return usuarioDAL.EliminarUsuario(usuario2);
        }
        public static List<Usuario> ListaUsuario(string usuario, string pass)
        {
            return UsuarioDAL.ListaUsuario(usuario, pass);
        }
    }
}
