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
    public class MozoDAL
    {
        public bool InsertarMozo(Mozo mozo)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertarMozo = "sp_insertarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spInsertarMozo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroDoc", mozo.NroDoc);
                cmd.Parameters.AddWithValue("@nombre", mozo.Nombre);
                cmd.Parameters.AddWithValue("@apellido", mozo.Apellido);
                cmd.Parameters.AddWithValue("@comision", mozo.Comision);
                cmd.Parameters.AddWithValue("@fechaIngreso", mozo.FechaIngreso);
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

        public bool ModificarMozo(Mozo mozo1)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spModificarMozo = "sp_modificarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spModificarMozo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nroDoc", mozo1.NroDoc);
                cmd.Parameters.AddWithValue("@nombre", mozo1.Nombre);
                cmd.Parameters.AddWithValue("@apellido", mozo1.Apellido);
                cmd.Parameters.AddWithValue("@comision", mozo1.Comision);
                cmd.Parameters.AddWithValue("@fechaIngreso", mozo1.FechaIngreso);
                cmd.Parameters.AddWithValue("@idMozoModificar", mozo1.IdMozo);
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

        public bool EliminarMozo(Mozo mozo2)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spEliminarMozo = "sp_eliminarMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spEliminarMozo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMozoEliminar", mozo2.IdMozo);
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

        //VERIFICAR SI EL OBJETO NO ES NULO
        public static Mozo BuscarMozo(SqlDataReader dr)
        {
            var m = new Mozo();
            if (!dr.IsDBNull(0))
            {
                m.IdMozo = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1))
            {
                m.NroDoc = dr.GetInt32(1);
            }
            if (!dr.IsDBNull(2))
            {
                m.Nombre = dr.GetString(2);
            }
            if (!dr.IsDBNull(3))
            {
                m.Apellido = dr.GetString(3);
            }
            if (!dr.IsDBNull(4))
            {
                m.Comision = dr.GetFloat(4);
            }
            if (!dr.IsDBNull(5))
            {
                m.FechaIngreso = dr.GetDateTime(5);
            }
            return m;
        }

        //OBTENER/LISTAR LOS MOZOS
        public static List<Mozo> LstMozos(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Mozo> lst = new List<Mozo>();
            Mozo m = null;
            try
            {
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * " +
                                  "from MOZOS" +
                                  " where idMozo = '" + id + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    m = BuscarMozo(dr);
                    lst.Add(m);
                }
                con.Close();
                return lst;

            }
            catch (Exception)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error");
            }
            finally
            {
                con.Close();
            }
        }

        //SELECCIONAR ID MOZO
        public static Mozo SeleccionarIDMozo(Mozo m)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Mozo mozo = null;
            try
            {
                string spSeleccionarIDMozo = "sp_seleccionarIDMozo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spSeleccionarIDMozo;
                cmd.Parameters.AddWithValue("@idMozo", m.IdMozo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    mozo = BuscarMozo(dr);
                }
                con.Close();
                return mozo;

            }
            catch (Exception)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error");
            }
            finally
            {
                con.Close();
            }
        }
    }
}

