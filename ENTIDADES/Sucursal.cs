using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Direccion { get; set; }
        public string RazonSocial { get; set; }
        public string NroCuit { get; set; }
        public float IngresosBrutos { get; set; }
        public int IdTipoIva { get; set; }
    }
}
