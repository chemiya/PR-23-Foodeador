using NetCoreAPIMysql.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMysql.data
{
    public interface IFoodeadorRepository
    {
       
        Task<bool> Insert(Usuario usuario);

        Task<bool> InsertSupermercado(Supermercado supermercado);

        Task<bool> InsertProducto(Producto producto);

        Task<bool> InsertPrecio(Precio precio);
        Task<Usuario> Identificar(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllUsuarios();

        Task<IEnumerable<Producto>> ProductosUsuario(int id);

        Task<IEnumerable<Supermercado>> SupermercadosUsuario(int id);

        Task<IEnumerable<Supermercado>> BuscarSupermercado(string nombre);
        Task<IEnumerable<Supermercado>> BuscarSupermercadosTodos();

        

        Task<Producto> DetalleProducto(int id);
        Task<Supermercado> DetalleSupermercado(int id);

        Task<IEnumerable<Producto>> BuscarProducto(string nombre);
        Task<IEnumerable<Producto>> BuscarProductosTodos();

        Task<IEnumerable<Precio>> PreciosUsuario(int id);

        Task<IEnumerable<Precio>> PreciosProducto(int id);

        Task<IEnumerable<Precio>> PreciosSupermercado(int id);

        Task<bool> DeleteSupermercado(int id);

        Task<bool> DeleteProducto(int id);

        Task<bool> UpdateProducto(Producto producto);

        Task<bool> UpdateSupermercado(Supermercado supermercado);



    }
}
