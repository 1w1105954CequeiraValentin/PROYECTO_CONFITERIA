using BLL;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO_CONFITERIA
{
    public partial class Mozos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGVMozo();
            }
        }
        public void cargarGVMozo()
        {
            DataTable gv = BLL.MozoBLL.CargarGVMozos();
            gvMozos.DataSource = gv;
            gvMozos.DataBind();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
        protected void gvMozos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idMozo = Convert.ToInt32(e.CommandArgument);
            ViewState["idMozo"] = idMozo;
            if (e.CommandName.Equals("Modificar"))
            {
                Mozo m = MozoBLL.SeleccionarIDMozo(int.Parse(ViewState["idMozo"].ToString()));
                txtNroDocModificar.Text = m.NroDoc.ToString();
                txtNombreModificar.Text = m.Nombre.ToString();
                txtApellidoModificar.Text = m.Apellido.ToString();
                txtComisionModificar.Text = m.Comision.ToString();
                txtFechaModificar.Text = m.FechaIngreso.ToString();
                ViewState["idMozo"] = m.IdMozo;
            }
        }

        protected void btnModificarMozo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}