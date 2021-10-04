using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROYECTO_CONFITERIA
{
    public partial class Sucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGVSucursal();
                cargarComboTiposIvas();
            }
        }
        public void cargarGVSucursal()
        {
            DataTable gv = BLL.SucursalBLL.CargarGV();
            gvSucursales.DataSource = gv;
            gvSucursales.DataBind();
        }
        protected void gvSucursales_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        public void cargarComboTiposIvas()
        {
            DataTable tabla = BLL.SucursalBLL.ObtenerTipoIva();
            cboTipoIva.DataSource = tabla;
            cboTipoIva.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboTipoIva.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboTipoIva.DataBind();
            cboTipoIva.Items.Insert(0, new ListItem("Seleccione un Tipo de Iva..."));
        }
    }
}