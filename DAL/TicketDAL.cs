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
                cmd.Parameters.AddWithValue("@nroTicket", t.NroTicket);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@idSucursal", t.IdSucursal);
                cmd.Parameters.AddWithValue("@idMozo", t.IdMozo);
                cmd.Parameters.AddWithValue("@idUsuario", t.IdUsuario);

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
                cmd.Parameters.AddWithValue("@idArticulo", d.IdArticulo);
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
