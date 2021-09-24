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
    public class UsuarioDAL
    {
        public bool InsertarUsuario(Usuario usuario)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertarUsuario = "sp_insertarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spInsertarUsuario;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", usuario.Password);
                cmd.Parameters.AddWithValue("@idRol", usuario.IdRolUsuario);
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

        public bool ModificarUsuario(Usuario usuario1)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spModificarUsuario = "sp_modificarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spModificarUsuario;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario1.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", usuario1.Password);
                cmd.Parameters.AddWithValue("@idRol", usuario1.IdRolUsuario);
                cmd.Parameters.AddWithValue("@idUsuario", usuario1.IdUsuario);
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

        public bool EliminarUsuario(Usuario usuario2)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spEliminarUsuario = "sp_eliminarUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spEliminarUsuario;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuarioEliminar", usuario2.IdUsuario);
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
        public static Usuario BuscarUsuarios(SqlDataReader dr)
        {
            var u = new Usuario();
            if (!dr.IsDBNull(0))
            {
                u.IdUsuario = dr.GetInt32(0);
            }
            if (!dr.IsDBNull(1))
            {
                u.NombreUsuario = dr.GetString(1);
            }
            if (!dr.IsDBNull(2))
            {
                u.Password = dr.GetString(2);
            }
            if (!dr.IsDBNull(3))
            {
                u.IdRolUsuario = dr.GetInt32(3);
            }
          
            return u;
        }

        //OBTENER/LISTAR LOS USUARIOS
        public static List<Usuario> LstUsuarios(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Usuario> lst = new List<Usuario>();
            Usuario u = null;
            try
            {
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * " +
                                  "from USUARIOS" +
                                  " where idUsuario = '" + id + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    u = BuscarUsuarios(dr);
                    lst.Add(u);
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

        //SELECCIONAR ID ARTICULO
        public static Usuario SeleccionarIDUsuario(Usuario u)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario usu = null;
            try
            {
                string spSeleccionarIDUsuario = "sp_seleccionarIDUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spSeleccionarIDUsuario;
                cmd.Parameters.AddWithValue("@idArticulo", u.IdUsuario);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usu = BuscarUsuarios(dr);
                }
                con.Close();
                return usu;

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
