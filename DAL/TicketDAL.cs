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
    public class TicketDAL
    {
        //INSERTAR TICKET
        public static int InsertarTicket(Ticket t)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                //int id;
                string nombreSP = "sp_insertarTicket";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = nombreSP;
                //cmd.Parameters.AddWithValue("@nroTicket", t.NroTicket);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@idSucursal", 1);
                cmd.Parameters.AddWithValue("@idMozo", t.IdMozo);
                cmd.Parameters.AddWithValue("@idUsuario", 10);

                SqlParameter outputIdParam = new SqlParameter("@nroTicket", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputIdParam);
                //Conexion.transaction = Conexion.conexion.BeginTransaction();
                //Conexion.Cmd.Transaction = Conexion.transaction;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                int id = (int)outputIdParam.Value;
                return id;
                //Conexion.CommitTransaction();
                //if (fila > 0)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
            catch (SqlException e)
            {
                //Conexion.BeginTransaction();
                //return false;
                throw new Exception(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool InsertarDetalleTicket(Detalle_Ticket d)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertar = "sp_insertarDetalleTicket";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spInsertar;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                cmd.Parameters.AddWithValue("@pre_unit", d.PrecioUnitario);
                cmd.Parameters.AddWithValue("@nro_ticket", d.NroTicket);
                cmd.Parameters.AddWithValue("@id_articulo", d.IdArticulo);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("Ha ocurrido un error" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable CargarGVDetalleTicket()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string sp_listarDetalle = "sp_detalleTicket";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp_listarDetalle;
                //SqlDataReader dr = cmd.ExecuteReader();

                DataTable GV = new DataTable();
                GV.Columns.AddRange(new DataColumn[] {
                    new DataColumn("idUsuario", typeof(int)),
                    new DataColumn("nombreUsuario", typeof(string)),
                    new DataColumn("pass", typeof(string)),
                    new DataColumn("idRolUsuario", typeof(int))
                });

                cmd.Parameters.Clear();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GV.Rows.Add(
                            dr["idUsuario"].ToString(),
                            dr["nombreUsuario"].ToString(),
                            dr["pass"].ToString(),
                            dr["idRolUsuario"].ToString()
                            );
                    }
                }


                return GV;
            }
            catch (SqlException e)
            {

                throw new Exception("Ha ocurrido un error" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable ObtenerArticulos()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from ARTICULOS";
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
        public static DataTable ObtenerMozos()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from MOZOS";
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
        public static Articulo BuscarArticulos(SqlDataReader dr)
        {
            var a = new Articulo();
            if (!dr.IsDBNull(0))
            {
                a.IdArticulo = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1))
            {
                a.Descripcion = dr.GetString(1);
            }
            if (!dr.IsDBNull(2))
            {
                a.Stock = dr.GetInt32(2);
            }
            if (!dr.IsDBNull(3))
            {
                a.Precio = dr.GetDouble(3);
            }
            if (!dr.IsDBNull(4))
            {
                a.IdRubro = dr.GetInt32(4);
            }
            return a;
        }
        public static Articulo SeleccionarIDArticulo(int a)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Articulo art = new Articulo();
            try
            {
                string spSeleccionarIDArticulo = "sp_cargarModal";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spSeleccionarIDArticulo;
                cmd.Parameters.AddWithValue("@idArt", a);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    art = BuscarArticulos(dr);
                }
                con.Close();
                return art;

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
