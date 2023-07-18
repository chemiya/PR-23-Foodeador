using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMysql.model
{
    public class Supermercado
    {
        public int id { get; set; }
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string direccionCompleta { get; set; }
        public string localizacion { get; set; }

        public string fechaApertura { get; set; }

        public string horario { get; set; }

        public string foto { get; set; }
    }
}
