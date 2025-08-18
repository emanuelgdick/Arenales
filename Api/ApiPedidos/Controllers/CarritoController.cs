using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;

namespace ApiPedidos.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    //[ApiController]
    public class CarritoController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        public CarritoController(db_a6292f_pedidosContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Carrito> lista = new List<Carrito>();

            try
            {
                lista = _dbcontext.Carritos.Include(s=>s.CarritoItems).ToList();
                


                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idCarrito:int}")]
        public IActionResult Obtener(long idCarrito)
        {
            Carrito oCarrito = _dbcontext.Carritos.Find(idCarrito);

            if (oCarrito == null)
            {
                return BadRequest("Carrito no encontrado");

            }

            try
            {

                oCarrito = _dbcontext.Carritos.Include(s => s.CarritoItems).Where(p => p.Id == idCarrito).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCarrito });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCarrito });


            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<Carrito> Guardar([FromBody] Carrito objeto)
        {

            Carrito r = new Carrito();
            long id = 0;

            int nro = _dbcontext.Carritos.Count() + 1;
            objeto.Nro = nro;
            _dbcontext.Carritos.Add(objeto);
            try
            {
                _dbcontext.SaveChanges();
            }
            catch (Exception ex) {
                 StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }


            r = _dbcontext.Carritos.OrderByDescending(u => u.Id).FirstOrDefault();
            return r;

        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Carrito objeto)
        {
            Carrito oCarrito = _dbcontext.Carritos.Find(objeto.Id);

            if (oCarrito == null)
            {
                return BadRequest("Carrito no encontrada");

            }

            try
            {
               // oCarrito.Descripcion = objeto.Descripcion is null ? oCarrito.Descripcion : objeto.Descripcion;
                _dbcontext.Carritos.Update(oCarrito);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Eliminar/{idCarrito:int}")]
        public IActionResult Eliminar(long idCarrito)
        {
            Carrito oCarrito = _dbcontext.Carritos.Find(idCarrito);
            if (oCarrito == null)
            {
                return BadRequest("Carrito no encontrado");
            }

            try
            {

                _dbcontext.Carritos.Remove(oCarrito);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
