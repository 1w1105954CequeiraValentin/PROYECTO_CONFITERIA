using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SucursalDAL
    {
        public bool InsertarSucursal(Sucursal sucursal)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertarSucursal = "sp_insertarSucursal";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spInsertarSucursal;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@direccion", sucursal.Direccion);
                cmd.Parameters.AddWithValue("@razonSocial", sucursal.RazonSocial);
                cmd.Parameters.AddWithValue("@nroCuit", sucursal.NroCuit);
                cmd.Parameters.AddWithValue("@ingBrutos", sucursal.IngresosBrutos);
                cmd.Parameters.AddWithValue("@idTipoIva", sucursal.IdTipoIva);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
