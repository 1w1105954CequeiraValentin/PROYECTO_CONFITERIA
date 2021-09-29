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
            //int id = Convert.ToInt32(gvArticulos.SelectedRow.Cells[1].Text);

            if (e.CommandName == "Modificar")
            {
                //CARGAR EL ARTICULO EN LA MODAL (POR MEDIO DE LA LISTA) Y EN EL BOTON GUARDAR DE LA MODAL MODIFICO
                List<Articulo> lst = BLL.ArticuloBLL.LstArticulos(idArticulo);

                //ESTE FOREACH RECORRE LA TABLA Y CARGA LOS DATOS EN LOS TXT
                foreach (var x in lst)
                {
                    txtDescripcion.Text = x.Descripcion;
                    txtStock.Text = x.Stock.ToString();
                    txtPrecio.Text = x.Precio.ToString();
                    //cboRubro1.Text = x.IdRubro.ToString();
                    cargarComboRubro();
                }
            }

            if (e.CommandName == "Eliminar")
            {
                
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

        protected void btnModificarArticulo_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}