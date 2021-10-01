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
        public static bool InsertarUsuario(Usuario usuario)
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
                cmd.Parameters.AddWithValue("@password", EncryptKeys.EncriptarPassword(usuario.Password, "Keys"));
                cmd.Parameters.AddWithValue("@idRol", usuario.IdRolUsuario);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool ModificarUsuario(Usuario usuario1)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spModificarUsuario = "sp_modificarUsuarios";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spModificarUsuario;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario1.NombreUsuario);
                cmd.Parameters.AddWithValue("@password", EncryptKeys.EncriptarPassword(usuario1.Password, "Keys"));
                cmd.Parameters.AddWithValue("@idRol", usuario1.IdRolUsuario);
                cmd.Parameters.AddWithValue("@idUsuario", usuario1.IdUsuario);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return true;
            }
            catch (SqlException e)
            {
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool EliminarUsuario(int idUsu)
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
                cmd.Parameters.AddWithValue("@idUsuarioEliminar", idUsu);
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
        public static List<Usuario> LstUsuarios()
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
                                  "from USUARIOS";
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
        public static Usuario SeleccionarIDUsuario(int u)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Usuario usu = new Usuario();
            try
            {
                string spSeleccionarIDUsuario = "sp_seleccionarIDUsuario";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spSeleccionarIDUsuario;
                cmd.Parameters.AddWithValue("@idUsuario", u);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usu = BuscarUsuarios(dr);
                }
                con.Close();
                return usu;

            }
            catch (SqlException e)
            {
                //Conexion.BeginTransaction();
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }

        //INICIAR SESION LOGIN
        public static List<Usuario> ListaUsuario(string usuario, string pass)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Usuario> lst = new List<Usuario>();
            Usuario us = null;
            try
            {
                string spIniciarSesion = "sp_iniciarSesion";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spIniciarSesion;
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lst.Add(BuscarUsuarios(dr));
                }
                return lst;
            }
            catch (SqlException e)
            {
                //agregar alerta
                throw new Exception("Ha ocurrido un error" + e);
            }
            finally
            {
                con.Close();
            }
        }
        public static DataTable CargarGVUsuario()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                string sp_listarUsuarioGrid = "sp_listarUsuarios";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp_listarUsuarioGrid;
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
        public static DataTable ObtenerRolUsuario()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from ROLES_USUARIOS";
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
