using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO_CONFITERIA
{
    public partial class PaginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["nombreDeUsuario"];

            if (user == null)
            {
                Response.Redirect("Login2.aspx");
            }

            Bienvenido.InnerText = "Bienvenido " + user.NombreUsuario;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("nombreDeUsuario");
            Response.Redirect("Login2.aspx");
        }
    }
}