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
        public static bool InsertarSucursal(Sucursal sucursal)
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

        public static DataTable CargarGV()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string sp_listarSucursalesGrid = "sp_listarSucursales";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp_listarSucursalesGrid;
                //SqlDataReader dr = cmd.ExecuteReader();

                DataTable GV = new DataTable();
                GV.Columns.AddRange(new DataColumn[] {
                    new DataColumn("idSucursal", typeof(int)),
                    new DataColumn("direccion", typeof(string)),
                    new DataColumn("razonSocial", typeof(string)),
                    new DataColumn("nroCuit", typeof(string)),
                    new DataColumn("ingresosBrutos", typeof(double)),
                    new DataColumn("idTipoIva", typeof(int))
                });

                cmd.Parameters.Clear();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GV.Rows.Add(
                            dr["idSucursal"].ToString(),
                            dr["direccion"].ToString(),
                            dr["razonSocial"].ToString(),
                            dr["nroCuit"].ToString(),
                            dr["ingresosBrutos"].ToString(),
                            dr["idTipoIva"].ToString()
                            );
                    }
                }


                return GV;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable ObtenerTipoIva()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from TIPOS_IVAS";
                con.ConnectionString = Conexion.ObtenerConexion();
                cmd.Connection = con;
                cmd.CommandText = query;
                con.Open();
                tabla.Load(cmd.ExecuteReader());
                return tabla;

            }
            catch (Exception e)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
