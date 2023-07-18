using Microsoft.AspNetCore.Mvc;
using NetCoreAPIMysql.data;
using NetCoreAPIMysql.model;

namespace back.Controllers
{
    [Route("api/")]
    [ApiController]
    public class Foodeador : ControllerBase
    {
        private readonly IFoodeadorRepository _foodeadorRepository;

        public Foodeador(IFoodeadorRepository foodeadorRepository)
        {
            _foodeadorRepository = foodeadorRepository;
        }



       

        [HttpPost]
        [Route("usuario/identificar")]
        public async Task<IActionResult> Identificar([FromBody] Usuario usuario)
        {
            
            return Ok(await _foodeadorRepository.Identificar(usuario));
            
        }

        [HttpGet]
        [Route("usuario")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _foodeadorRepository.GetAllUsuarios());
        }

        [HttpGet]
        [Route("producto/usuario/{id}")]
        public async Task<IActionResult> ProductosUsuario(int id)
        {
            return Ok(await _foodeadorRepository.ProductosUsuario(id));
        }

        [HttpGet]
        [Route("supermercado/usuario/{id}")]
        public async Task<IActionResult> SupermercadosUsuario(int id)
        {
            Console.WriteLine("id usuario");
            Console.WriteLine(id);
            return Ok(await _foodeadorRepository.SupermercadosUsuario(id));
        }

        [HttpGet]
        [Route("precio/usuario/{id}")]
        public async Task<IActionResult> PreciosUsuario(int id)
        {
            return Ok(await _foodeadorRepository.PreciosUsuario(id));
        }

        [HttpGet]
        [Route("supermercado")]
        public async Task<IActionResult> buscarSupermercado([FromQuery] string nombre)
        {
            Console.WriteLine("nombre enc");
            Console.WriteLine(nombre);
            return Ok(await _foodeadorRepository.BuscarSupermercado(nombre));
        }

        [HttpGet]
        [Route("supermercado/todos")]
        public async Task<IActionResult> buscarSupermercadosTodos()
        {
          
            return Ok(await _foodeadorRepository.BuscarSupermercadosTodos());
        }


        [HttpGet]
        [Route("producto")]
        public async Task<IActionResult> buscarProducto([FromQuery] string nombre)
        {
            Console.WriteLine("nombre enc");
            Console.WriteLine(nombre);
            return Ok(await _foodeadorRepository.BuscarProducto(nombre));
        }

        [HttpGet]
        [Route("producto/todos")]
        public async Task<IActionResult> buscarProductosTodos()
        {

            return Ok(await _foodeadorRepository.BuscarProductosTodos());
        }

        [HttpGet]
        [Route("precio/supermercado/{id}")]
        public async Task<IActionResult> PreciosSupermercado(int id)
        {
            return Ok(await _foodeadorRepository.PreciosSupermercado(id));
        }

        [HttpGet]
        [Route("precio/producto/{id}")]
        public async Task<IActionResult> PreciosProducto(int id)
        {
            return Ok(await _foodeadorRepository.PreciosProducto(id));
        }

        [HttpDelete]
        [Route("supermercado/{id}")]
        public async Task<IActionResult> DeleteSupermercado(int id)
        {
            await _foodeadorRepository.DeleteSupermercado(id);
            return NoContent();
        }

        [HttpDelete]
        [Route("producto/{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            await _foodeadorRepository.DeleteProducto(id);
            return NoContent();
        }

        [HttpPut]
        [Route("producto")]
        public async Task<IActionResult> UpdateProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _foodeadorRepository.UpdateProducto(producto);
            return NoContent();
        }

        [HttpPut]
        [Route("supermercado")]
        public async Task<IActionResult> UpdateSupermercado([FromBody] Supermercado supermercado)
        {
            if (supermercado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _foodeadorRepository.UpdateSupermercado(supermercado);
            return NoContent();
        }

        [HttpPost]
        [Route("usuario/crear")]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuario usuario)
        {
            if(usuario== null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created= _foodeadorRepository.Insert(usuario);
            return Created("created", usuario);
        }


        [HttpPost]
        [Route("supermercado/crear")]
        public async Task<IActionResult> CreateSupermercado([FromBody] Supermercado supermercado)
        {
            if (supermercado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = _foodeadorRepository.InsertSupermercado(supermercado);
            return Created("created", supermercado);
        }

        [HttpPost]
        [Route("producto/crear")]
        public async Task<IActionResult> CreateProducto([FromBody] Producto producto)

        {
            if (producto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = _foodeadorRepository.InsertProducto(producto);
            return Created("created", producto);
        }

        [HttpPost]
        [Route("precio/crear")]
        public async Task<IActionResult> CreatePrecio([FromBody] Precio precio)
        {

            Console.WriteLine("entro a crear precio");
            if (precio == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = _foodeadorRepository.InsertPrecio(precio);
            return Created("created", precio);
        }

        [HttpGet("producto/{id}")]
        public async Task<IActionResult> DetalleProducto(int id)
        {
            return Ok(await _foodeadorRepository.DetalleProducto(id));
        }

        [HttpGet("supermercado/{id}")]
        public async Task<IActionResult> DetalleSupermercado(int id)
        {
            return Ok(await _foodeadorRepository.DetalleSupermercado(id));
        }






    }
}
