using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMysql.model
{
    public class Producto
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }
        public string marca { get; set; }

        public string descripcion { get; set; }

        public string tipo { get; set; }
    }
}
