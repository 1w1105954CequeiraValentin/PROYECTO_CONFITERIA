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
        public static bool InsertarArticulo(Articulo articulo)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spInsertarArticulo = "sp_insertarArticulos";
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

        public static bool ModificarArticulo(Articulo articulo1)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spModificarArticulo = "sp_modificarArticulos";
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
            catch (SqlException e)
            {
                throw new Exception("Ha ocurrido un error " + e);
            }
            finally
            {
                con.Close();
            }
        }

        public static bool EliminarArticulo(int id)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string spEliminarArticulo = "sp_eliminarArticulos";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spEliminarArticulo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idArticuloEliminar", id);
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

        //OBTENER/LISTAR LOS ARTICULOS
        public static List<Articulo> LstArticulos(int id)
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            List<Articulo> lst = new List<Articulo>();
            Articulo a = new Articulo();
            try
            {
                string spListadoArticulos = "sp_listadoArticulos";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = spListadoArticulos;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@idArt", id);
                //cmd.ExecuteNonQuery();
                
                //SqlDataReader dr = cmd.ExecuteReader();
                //lst.Clear();

                //while (dr.Read())
                //{
                //    a = BuscarArticulos(dr);
                //    lst.Add(a);
                //}
                //con.Close();
                //return lst;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        a.IdArticulo = int.Parse(dr["idArticulo"].ToString());
                        a.Descripcion = dr["descripcion"].ToString();
                        a.Stock = int.Parse(dr["stock"].ToString());
                        a.Precio = double.Parse(dr["precio_articulo"].ToString());
                        a.IdRubro = int.Parse(dr["idRubro"].ToString());

                        lst.Add(a);
                        
                    }
                    return lst;
                }

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

        public static DataTable CargarGV()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            
            try
            {
                string sp_listarArticulosGrid = "sp_listarArticulos";
                con.ConnectionString = Conexion.ObtenerConexion();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp_listarArticulosGrid;
                //SqlDataReader dr = cmd.ExecuteReader();

                DataTable GV = new DataTable();
                GV.Columns.AddRange(new DataColumn[] {
                    new DataColumn("idArticulo", typeof(int)),
                    new DataColumn("descripcion", typeof(string)),
                    new DataColumn("stock", typeof(int)),
                    new DataColumn("precio_articulo", typeof(double)),
                    new DataColumn("idRubro", typeof(int))
                });

                cmd.Parameters.Clear();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        GV.Rows.Add(
                            dr["idArticulo"].ToString(),
                            dr["descripcion"].ToString(),
                            dr["stock"].ToString(),
                            dr["precio_articulo"].ToString(),
                            dr["idRubro"].ToString()
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

        public static DataTable ObtenerRubroArticulo()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            try
            {
                string query = "select * from RUBROS_ARTICULOS";
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
