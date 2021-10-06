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
    public partial class Ticket : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarComboArticulo();
                cargarComboMozo();
            }
        }
        protected void gvDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private void CargarTabla()
        {
            DataTable dt;
            if (Session["datos"] == null)
            {
                dt = new DataTable();
                dt.Columns.Add("Codigo Articulo");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio Unitario");
                dt.Columns.Add("Importe");
            }
            else
            {
                dt = Session["datos"] as DataTable;
            }
        }

        public void cargarComboArticulo()
        {
            DataTable tabla = BLL.TicketBLL.ObtenerArticulos();
            cboArticulo.DataSource = tabla;
            cboArticulo.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboArticulo.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboArticulo.DataBind();
            cboArticulo.Items.Insert(0, new ListItem("Seleccione un Articulo..."));
        }
        public void cargarComboMozo()
        {
            DataTable tabla = BLL.TicketBLL.ObtenerMozos();
            cboMozo.DataSource = tabla;
            cboMozo.DataTextField = tabla.Columns[2].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboMozo.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboMozo.DataBind();
            cboMozo.Items.Insert(0, new ListItem("Seleccione un Mozo..."));
        }

        protected void btnGenerarTicket_Click(object sender, EventArgs e)
        {
            //if (ValidarCamposTabla())
            //{
            //btnGenerarTicket.Visible = true;

            double total = 0;
            DataTable dt;
            if (Session["datos"] != null)
            {
                dt = Session["datos"] as DataTable;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("Codigo Articulo");
                dt.Columns.Add("Cantidad");
                dt.Columns.Add("Precio Unitario");
                dt.Columns.Add("Importe");
            }
            DataRow row = dt.NewRow();
            double importe = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(ViewState["precio"]);
            row["Codigo Articulo"] = cboArticulo.Text;
            row["Cantidad"] = txtCantidad.Text;
            row["Precio Unitario"] = ViewState["precio"];
            row["Importe"] = importe.ToString();
            dt.Rows.Add(row);




            gvDetalle.DataSource = dt;
            gvDetalle.DataBind();
            Session["datos"] = dt;

            //Recorro el gridview para acumular la columna importe
            foreach (GridViewRow x in gvDetalle.Rows)
            {
                total += Convert.ToDouble(row["Importe"].ToString());
            }

            /*lblMsjTotal.Text = "Total: ";
            lblMsjTotal.Visible = true;
            lblTotal.Visible = true;
            lblTotal.Text = " $" + total.ToString();*/
            //}
            /*else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "validacionAgregarAlCarro();", true);
            }*/
        }

        protected void cboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idArticulo = Convert.ToInt32(cboArticulo.SelectedValue);
            Articulo ar = BLL.ArticuloBLL.SeleccionarIDArticulo(idArticulo);
            double precio = ar.Precio;
            ViewState["precio"] = precio;
        }

        protected void btnCobrar_Click(object sender, EventArgs e)
        {

        }
    }
}