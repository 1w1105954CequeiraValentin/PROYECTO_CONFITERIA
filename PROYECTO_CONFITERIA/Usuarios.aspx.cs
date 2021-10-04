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
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGVUsuarios();
                cargarComboRolUsuario();
            }
        }
        public void cargarGVUsuarios()
        {
            DataTable gv = BLL.UsuarioBLL.CargarGVUsuario();
            gvUsuarios.DataSource = gv;
            gvUsuarios.DataBind();
        }
        public bool InsertarUsuario(string nomUs, string pass, int idRol)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = nomUs;
            usuario.Password = pass;
            usuario.IdRolUsuario = idRol;

            return UsuarioBLL.InsertarUsuario(usuario);
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!validarCamposVacios())
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjDebeIngresarTodosLosDatos();", true);
            }
            else if(cboRolUsuario.SelectedIndex > 0)
            {
                InsertarUsuario(txtNombreUsuario.Text, txtPassword.Text, Convert.ToInt32(cboRolUsuario.Text));
                cargarGVUsuarios();
                lblSeleccioneRol.Text = "USUARIO REGISTRADO";
                lblSeleccioneRol.Visible = true;
            }
            else
            {
                lblSeleccioneRol.Visible = true;
            }
            
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idUs = Convert.ToInt32(e.CommandArgument);
            //ViewState["idUsuario"] = idUs;

            if (e.CommandName.Equals("Modificar"))
            {
                Usuario u = UsuarioBLL.SeleccionarIDUsuario(idUs);
                txtNombreUsuarioModificar.Text = u.NombreUsuario.ToString();
                txtPassModificar.Text = u.Password.ToString();
                cargarComboRolModificar();
                idUs = u.IdUsuario;
                //ViewState["idUsuario"] = u.IdUsuario;
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                //int idUsuario = (int)ViewState["IdUsuario"];
                if (BLL.UsuarioBLL.EliminarUsuario(idUs))
                {
                    cargarGVUsuarios();
                }
            }
        }
        public void cargarComboRolUsuario()
        {
            DataTable tabla = BLL.UsuarioBLL.ObtenerRolUsuario();
            cboRolUsuario.DataSource = tabla;
            cboRolUsuario.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboRolUsuario.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboRolUsuario.DataBind();
            cboRolUsuario.Items.Insert(0, new ListItem("Seleccione un Rol..."));
        }

        public void cargarComboRolModificar()
        {
            DataTable tabla = BLL.UsuarioBLL.ObtenerRolUsuario();
            cboRolUsuarioModificar.DataSource = tabla;
            cboRolUsuarioModificar.DataTextField = tabla.Columns[1].ColumnName;//datatextfield MUESTRA EL NOMBRE DE LO QUE MOSTRAS
            cboRolUsuarioModificar.DataValueField = tabla.Columns[0].ColumnName;//datatextvalue OBTIENE EL VALOR DELO QUE MOSTRAS
            cboRolUsuarioModificar.DataBind();
            cboRolUsuarioModificar.Items.Insert(0, new ListItem("Seleccione un Rol..."));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }
        public bool ModificarUsuario(string nomUsua, string pass, int idRol, int idUs)
        {
            BLL.UsuarioBLL usBLL = new UsuarioBLL();
            Usuario usua = new Usuario();
            usua.IdUsuario = idUs;
            usua.NombreUsuario = nomUsua;
            usua.Password = pass;
            usua.IdRolUsuario = idRol;
            return BLL.UsuarioBLL.ModificarUsuario(usua);
        }
        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            int idU = (int)ViewState["idUsuario"];
            //if (string.IsNullOrEmpty(txtNombreUsuario.Text) || string.IsNullOrEmpty(txtPassword.Text) || cboRolUsuarioModificar.SelectedIndex.Equals(0))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjDebeIngresarTodosLosDatos();", true);
            //}
            //else
            //{
                ModificarUsuario(txtNombreUsuarioModificar.Text, txtPassModificar.Text, Convert.ToInt32(cboRolUsuarioModificar.Text), idU);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "MyFunction", "MsjRegistroModificado();", true);
                cargarGVUsuarios();
            //}
        }
        public bool validarCamposVacios()
        {

            //if (cboRolUsuario.SelectedItem.Equals(0))
            //{
            //    cboRolUsuario.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                txtNombreUsuario.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                return false;
            }
            
            return true;
        }
    }
}