using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        public static string ObtenerConexion()
        {
            string con = ConfigurationManager.ConnectionStrings["connDb"].ConnectionString;
            if (string.ReferenceEquals(con, string.Empty))
            {
                return string.Empty;
            }
            else
            {
                return con;
            }
        }

    }
}
