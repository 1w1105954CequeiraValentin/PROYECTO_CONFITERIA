using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO_CONFITERIA
{
    public partial class Login2 : System.Web.UI.Page
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool LoginUsuario(string usuario, string pass)
        {
            List<Usuario> lst = UsuarioBLL.ListaUsuario(usuario, pass);
            Usuario u = lst.FirstOrDefault(x => x.NombreUsuario == usuario && x.Password == pass);
            if (u != null)
            {
                Session["nombreDeUsuario"] = u;
                Response.Redirect("Index.aspx");

            }
            return true;
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            LoginUsuario(txtNombreUsuario.Text, txtPassword.Text);
        }
    }
}