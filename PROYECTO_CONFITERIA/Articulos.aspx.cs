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
    public partial class Articulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGVArticulos();
                cargarComboRubro();
            }
            
        }

        public void cargarGVArticulos()
        {
            DataTable gv = BLL.ArticuloBLL.CargarGV();
            gvArticulos.DataSource = gv;
            gvArticulos.DataBind();
        }

        protected void gvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //VARIABLE QUE VA A ALMACENAR EL ID DE LA FILA SELECCIONADA DE CUALQUIERA DE LOS DOS BOTONES A TRAVES DEL COMMANDARGUMENT
            int idArticulo = Convert.ToInt32(e.CommandArgument);
            ViewState["idArticulo"] = idArticulo;

            if (e.CommandName.Equals("Modificar"))
            {   
                Articulo a = ArticuloBLL.SeleccionarIDArticulo(int.Parse(ViewState["idArticulo"].ToString()));
                txtNombreModificar.Text = a.Descripcion;
                txtStockModificar.Text = a.Stock.ToString();
                txtPrecioModificar.Text = a.Precio.ToString();
                //cboRubroModificar.Text = a.IdRubro.ToString();
                cargarComboRubroModificar();
                ViewState["idArticulo"] = a.IdArticulo;
                
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                int idArtic = (int)ViewState["idArticulo"];
                if (BLL.ArticuloBLL.EliminarArticulo(idArtic))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjArticuloEliminado();", true);
                    cargarGVArticulos();
                }
            }
        }

        public void cargarComboRubro()
        {
            DataTable tabla = BLL.ArticuloBLL.ObtenerRubroArticulo();
            cboRubroArticulo.DataSource = tabla;
            cboRubroArticulo.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboRubroArticulo.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboRubroArticulo.DataBind();
            cboRubroArticulo.Items.Insert(0, new ListItem("Seleccione un Rubro..."));
        }

        public void cargarComboRubroModificar()
        {
            DataTable tabla = BLL.ArticuloBLL.ObtenerRubroArticulo();
            cboRubroModificar.DataSource = tabla;
            cboRubroModificar.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboRubroModificar.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboRubroModificar.DataBind();
            cboRubroModificar.Items.Insert(0, new ListItem("Seleccione un Rubro..."));
        }

        public bool InsertarArticulo(string descripcion, int stock, float precio, int idRubro)
        {
            ArticuloBLL articuloBLL = new ArticuloBLL();
            Articulo articulo = new Articulo();
            articulo.Descripcion = descripcion;
            articulo.Stock = stock;
            articulo.Precio = precio;
            articulo.IdRubro = idRubro;

            return ArticuloBLL.InsertarArticulo(articulo);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            InsertarArticulo(txtDescripcion.Text, Convert.ToInt32(txtStock.Text), Convert.ToInt32(txtPrecio.Text), Convert.ToInt32(cboRubroArticulo.Text));
            cargarGVArticulos();
        }

        public bool ModificarArticulo(string descripcion, int stock, double precio, int idRubro, int idArt)
        {
                BLL.ArticuloBLL artBLL = new ArticuloBLL();
                Articulo art = new Articulo();
                art.IdArticulo = idArt;
                art.Descripcion = descripcion;
                art.Stock = stock;
                art.Precio = precio;
                art.IdRubro = idRubro;
                return BLL.ArticuloBLL.ModificarArticulo(art);
        }
        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            int idArtic = (int)ViewState["idArticulo"];
            if (string.IsNullOrEmpty(txtNombreModificar.Text) || string.IsNullOrEmpty(txtStockModificar.Text) || string.IsNullOrEmpty(txtPrecioModificar.Text) || cboRubroModificar.SelectedIndex.Equals(0))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjDebeIngresarTodosLosDatos();", true);
            }
            else
            {
                ModificarArticulo(txtNombreModificar.Text, Convert.ToInt32(txtStockModificar.Text), Convert.ToDouble(txtPrecioModificar.Text), Convert.ToInt32(cboRubroModificar.Text), idArtic);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjRegistroModificado();", true);
                cargarGVArticulos();
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        public string validarCamposVacios()
        {

            string faltanDatos = "";
            
            if (string.IsNullOrEmpty(txtNombreModificar.Text))
            {
                faltanDatos += "Ingrese Descripción\n";
                txtNombreModificar.Focus();
            }
            if (string.IsNullOrEmpty(txtStockModificar.Text))
            {
                faltanDatos += "Ingrese Stock\n";
                txtStockModificar.Focus();
            }
            if (string.IsNullOrEmpty(txtPrecioModificar.Text))
            {
                faltanDatos += "Ingrese Precio\n";
                txtPrecioModificar.Focus();
            }
            if (cboRubroModificar.SelectedItem.Equals(0))
            {
                faltanDatos += "Seleccionar Rubro\n";
                cboRubroModificar.Focus();
            }
            return faltanDatos;
        }
    }
}