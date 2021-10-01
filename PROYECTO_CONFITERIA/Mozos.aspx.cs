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
        public bool InsertarMozo(int doc, string nombre, string apellido, double comision, DateTime fecha)
        {
            MozoBLL mozoBLL = new MozoBLL();
            Mozo mozo = new Mozo();
            mozo.NroDoc = doc;
            mozo.Nombre = nombre;
            mozo.Apellido = apellido;
            mozo.Comision = comision;
            mozo.FechaIngreso = fecha;
            return MozoBLL.InsertarMozo(mozo);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            InsertarMozo(Convert.ToInt32(txtDocumento.Text), txtNombre.Text, txtApellido.Text, Convert.ToDouble(txtComision.Text), Convert.ToDateTime(txtFechaIngreso.Text));
            cargarGVMozo();
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
            if (e.CommandName.Equals("Eliminar"))
            {
                int idMoz = (int)ViewState["idMozo"];
                if (BLL.MozoBLL.EliminarMozo(idMoz))
                {
                    cargarGVMozo();
                }
            }
        }
        public bool ModificarMozo(int nroDoc, string nombre, string apellido, double comision, DateTime fecha, int idMo)
        {
            BLL.MozoBLL mozoBLL = new MozoBLL();
            Mozo m = new Mozo();
            m.IdMozo = idMo;
            m.NroDoc = nroDoc;
            m.Nombre = nombre;
            m.Apellido = apellido;
            m.Comision = comision;
            m.FechaIngreso = fecha;
            return BLL.MozoBLL.ModificarMozo(m);
        }
        protected void btnModificarMozo_Click(object sender, EventArgs e)
        {
            int idM = (int)ViewState["idMozo"];
            if (string.IsNullOrEmpty(txtNroDocModificar.Text) || string.IsNullOrEmpty(txtNombreModificar.Text) || string.IsNullOrEmpty(txtApellidoModificar.Text) || string.IsNullOrEmpty(txtComisionModificar.Text) || string.IsNullOrEmpty(txtFechaModificar.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjDebeIngresarTodosLosDatos();", true);
            }
            else
            {
                ModificarMozo(Convert.ToInt32(txtNroDocModificar.Text), txtNombreModificar.Text, txtApellidoModificar.Text, Convert.ToDouble(txtComisionModificar.Text), Convert.ToDateTime(txtFechaModificar.Text), idM);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjRegistroModificado();", true);
                cargarGVMozo();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}