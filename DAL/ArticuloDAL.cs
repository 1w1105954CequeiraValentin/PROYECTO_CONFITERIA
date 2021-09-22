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
    public class ArticuloDAL
    {
        public bool InsertarArticulo(Articulo articulo)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertarArticulo = "sp_insertarArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spInsertarArticulo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                cmd.Parameters.AddWithValue("@stock", articulo.Stock);
                cmd.Parameters.AddWithValue("@precio_art", articulo.Precio);
                cmd.Parameters.AddWithValue("@idRubro", articulo.IdRubro);
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

        public bool ModificarArticulo(Articulo articulo1)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spModificarArticulo = "sp_modificarArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spModificarArticulo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", articulo1.Descripcion);
                cmd.Parameters.AddWithValue("@stock", articulo1.Stock);
                cmd.Parameters.AddWithValue("@precio_art", articulo1.Precio);
                cmd.Parameters.AddWithValue("@idRubro", articulo1.IdRubro);
                cmd.Parameters.AddWithValue("@idArticuloModificar", articulo1.IdArticulo);
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

        public bool EliminarArticulo(Articulo articulo2)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spEliminarArticulo = "sp_eliminarArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spEliminarArticulo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArticuloEliminar", articulo2.IdArticulo);
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
                a.Precio = dr.GetFloat(3);
            }
            if (!dr.IsDBNull(4))
            {
                a.IdRubro = dr.GetInt32(4);
            }
            return a;
        }

        //OBTENER/LISTAR LOS ARTICULOS
        public static List<Articulo> LstArticulos(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Articulo> lst = new List<Articulo>();
            Articulo a = null;
            try
            {
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * " +
                                  "from ARTICULOS" +
                                  " where idArticulo = '" + id +"'";
                SqlDataReader dr = cmd.ExecuteReader();
                lst.Clear();

                while (dr.Read())
                {
                    a = BuscarArticulos(dr);
                    lst.Add(a);
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
        public static Articulo SeleccionarIDArticulo(Articulo a)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            Articulo art = null;
            try
            {
                string spSeleccionarIDArticulo = "sp_seleccionarIDArticulo";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spSeleccionarIDArticulo;
                cmd.Parameters.AddWithValue("@idArticulo", a.IdArticulo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    art = BuscarArticulos(dr);
                }
                con.Close();
                return art;

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
