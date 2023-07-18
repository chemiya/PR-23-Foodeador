using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMysql.model
{
    public class Precio
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public int idProducto { get; set; }
        public int idSupermercado { get; set; }
        public double precio { get; set; }

        public string nombreProducto { get; set; }
        public string marcaProducto { get; set; }
        public string nombreSupermercado { get; set; }
        public string nombreUsuario { get; set; }

        public string fotoProducto { get; set; }
    }
}
