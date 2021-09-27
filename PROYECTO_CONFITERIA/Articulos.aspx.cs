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
            //cargarTabla();
        }
        
        //public void cargarTabla()
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn descripcion = dt.Columns.Add("Descripcion", typeof(string));

        //    DataRow row = dt.NewRow();
        //    row["descripcion"] = "Hola";
        //    dt.Rows.Add(row);
        //    dt.AcceptChanges();
        //    dgvUsers.DataSource = dt;
            
        //    dgvUsers.DataBind();
        //}
    }
}