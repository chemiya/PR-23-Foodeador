using Dapper;
using MySql.Data.MySqlClient;
using NetCoreAPIMysql.model;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIMysql.data
{
    public class FoodeadorRepository : IFoodeadorRepository
    {

        private readonly MySQLConfiguration _connectionString;

        public FoodeadorRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var db = dbConnection();
            var sql = @"select * from usuario";
            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<IEnumerable<Producto>> ProductosUsuario(int id)
        {
            var db = dbConnection();
            var sql = @"select * from producto where producto.idUsuario=@id";
            return await db.QueryAsync<Producto>(sql, new { id=id});
        }

        public async Task<IEnumerable<Supermercado>> SupermercadosUsuario(int id)
        {
            Console.WriteLine("super usuario");
            Console.WriteLine(id);
            var db = dbConnection();
            var sql = @"select * from supermercado where supermercado.idUsuario=@id";
            return await db.QueryAsync<Supermercado>(sql, new { id = id });
        }

        public async Task<IEnumerable<Precio>> PreciosUsuario(int id)
        {
            var db = dbConnection();
            var sql = @"select p.precio as precio, pr.nombre as nombreProducto,pr.foto as fotoProducto, pr.marca as marcaProducto, s.nombre as nombreSupermercado, u.username as nombreUsuario from precio p, usuario u, producto pr, supermercado s where p.idUsuario=@id and p.idSupermercado=s.id and p.idUsuario=u.id and p.idProducto=pr.id";
            return await db.QueryAsync<Precio>(sql, new { id = id });
        }

        public async Task<bool> DeleteSupermercado(int id)
        {
            var db = dbConnection();
            var sql = @"delete from supermercado where id=@id";
            var result = await db.ExecuteAsync(sql, new { id = id });
            return result > 0;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var db = dbConnection();
            var sql = @"delete from producto where id=@id";
            var result = await db.ExecuteAsync(sql, new { id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Precio>> PreciosSupermercado(int id)
        {
            var db = dbConnection();
            Console.WriteLine("id super:");
            Console.WriteLine(id);
            var sql = @"select p.precio as precio, pr.nombre as nombreProducto,pr.foto as fotoProducto, pr.marca as marcaProducto, s.nombre as nombreSupermercado, u.username as nombreUsuario from precio p, usuario u, producto pr, supermercado s where p.idSupermercado = @id and p.idSupermercado = s.id and p.idUsuario = u.id and p.idProducto = pr.id";
            return await db.QueryAsync<Precio>(sql, new { id = id });
        }

        public async Task<IEnumerable<Supermercado>> BuscarSupermercado(string nombre)
        {
            Console.WriteLine("nombre despues");
            Console.WriteLine(nombre);
            var db = dbConnection();
            var sql = @"select * from supermercado where nombre like '%"+nombre+"%'";
            Console.WriteLine(sql);
            
            return await db.QueryAsync<Supermercado>(sql, new {  });
        }

        public async Task<IEnumerable<Producto>> BuscarProducto(string nombre)
        {
            Console.WriteLine("nombre despues");
            Console.WriteLine(nombre);
            var db = dbConnection();
            var sql = @"select * from producto where nombre like '%" + nombre + "%'";
            Console.WriteLine(sql);

            return await db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<IEnumerable<Supermercado>> BuscarSupermercadosTodos()
        {
           
            var db = dbConnection();
            var sql = @"select * from supermercado ";
         

            return await db.QueryAsync<Supermercado>(sql, new { });
        }

        public async Task<IEnumerable<Producto>> BuscarProductosTodos()
        {

            var db = dbConnection();
            var sql = @"select * from producto ";


            return await db.QueryAsync<Producto>(sql, new { });
        }

        public async Task<IEnumerable<Precio>> PreciosProducto(int id)
        {
            var db = dbConnection();
            Console.WriteLine("id producto "+id);
            var sql = @"select p.precio as precio, pr.nombre as nombreProducto,pr.foto as fotoProducto, pr.marca as marcaProducto, s.nombre as nombreSupermercado, u.username as nombreUsuario from precio p, usuario u, producto pr, supermercado s where p.idProducto = @id and p.idSupermercado = s.id and p.idUsuario = u.id and p.idProducto = pr.id";
            return await db.QueryAsync<Precio>(sql, new { id = id });
        }

       


        public async Task<Usuario> Identificar(Usuario usuario)
        {
            Console.WriteLine(usuario.username);
            var db = dbConnection();
            var sql = @"select * from usuario where username= @username and password=@password";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { usuario.username, usuario.password});
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            Console.WriteLine(usuario.username);
            var db = dbConnection();
            var sql = @"insert into usuario(username, password, email) values (@username, @password, @email)";
            var result = await db.ExecuteAsync(sql, new { usuario.username, usuario.password, usuario.email });
            Console.WriteLine(result);
            return result > 0;
        }


        public async Task<bool> InsertSupermercado(Supermercado supermercado)
        {
            Console.WriteLine(supermercado.nombre);
            Console.WriteLine(supermercado.direccionCompleta);
            Console.WriteLine(supermercado.localizacion);
            Console.WriteLine(supermercado.horario);
            Console.WriteLine(supermercado.fechaApertura);
            Console.WriteLine(supermercado.foto);
            Console.WriteLine(supermercado.idUsuario);
            var db = dbConnection();
            var sql = @"insert into supermercado(nombre, direccionCompleta, localizacion,horario,fechaApertura,foto,idUsuario) values (@nombre, @direccionCompleta, @localizacion,@horario,@fechaApertura,@foto,@idUsuario)";
            var result = await db.ExecuteAsync(sql, new { supermercado.nombre,supermercado.direccionCompleta,supermercado.localizacion,supermercado.horario,supermercado.fechaApertura,supermercado.foto,supermercado.idUsuario});
            Console.WriteLine(result);
            return result > 0;
        }

        public async Task<bool> InsertProducto(Producto producto)
        {


            Console.WriteLine(producto.nombre);
            Console.WriteLine(producto.marca);
            Console.WriteLine(producto.descripcion);
            Console.WriteLine(producto.tipo);
            Console.WriteLine(producto.foto);
            Console.WriteLine(producto.idUsuario);

            var db = dbConnection();
            var sql = @"insert into producto(nombre, marca, descripcion,tipo,foto,idUsuario) values (@nombre, @marca, @descripcion,@tipo,@foto,@idUsuario)";
            var result = await db.ExecuteAsync(sql, new { producto.nombre, producto.marca, producto.descripcion, producto.tipo, producto.foto, producto.idUsuario });
            Console.WriteLine("resultado");
            Console.WriteLine(result);
            return result > 0;
        }

        public async Task<bool> InsertPrecio(Precio precio)
        {

            Console.WriteLine(precio.idProducto);
            Console.WriteLine(precio.idUsuario);
            Console.WriteLine(precio.idSupermercado);
            Console.WriteLine(precio.precio);

            var db = dbConnection();
            var sql = @"insert into precio(idProducto,idSupermercado,idUsuario,precio) values (@idProducto, @idSupermercado, @idUsuario,@precio)";
            var result = await db.ExecuteAsync(sql, new { precio.idProducto,precio.idSupermercado,precio.idUsuario,precio.precio });
            Console.WriteLine("resultado insert:"+result);
            return result > 0;
        }

        public async Task<Producto> DetalleProducto(int id)
        {
            var db = dbConnection();
            var sql = @"select * from producto where id= @id";
            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { id = id });
        }

        public async Task<Supermercado> DetalleSupermercado(int id)
        {
            var db = dbConnection();
            var sql = @"select * from supermercado where id= @id";
            return await db.QueryFirstOrDefaultAsync<Supermercado>(sql, new { id = id });
        }


        public async Task<bool> UpdateProducto(Producto producto)
        {
            var db = dbConnection();
            var sql = @"update producto set nombre=@nombre, foto=@foto, marca=@marca,descripcion=@descripcion, tipo=@tipo where id=@id";
            var result = await db.ExecuteAsync(sql, new { producto.nombre,producto.foto,producto.marca,producto.descripcion,producto.tipo,producto.id });

            return result > 0;
        }

        public async Task<bool> UpdateSupermercado(Supermercado supermercado)
        {
            var db = dbConnection();
            var sql = @"update supermercado set nombre=@nombre, direccionCompleta=@direccionCompleta, localizacion=@localizacion,fechaApertura=@fechaApertura, horario=@horario, foto=@foto where id=@id";
            var result = await db.ExecuteAsync(sql, new { supermercado.nombre, supermercado.direccionCompleta,supermercado.localizacion,supermercado.fechaApertura,supermercado.horario,supermercado.foto, supermercado.id});

            return result > 0;
        }

    }
}
