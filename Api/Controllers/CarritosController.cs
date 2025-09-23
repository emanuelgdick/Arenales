using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Carritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrito>>> GetCarrito()
        {
            return await _context.Carrito.ToListAsync();
        }

        // GET: api/Carritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrito>> GetCarrito(long id)
        {
            var carrito = await _context.Carrito.FindAsync(id);

            if (carrito == null)
            {
                return NotFound();
            }

            return carrito;
        }

        // GET: api/Carritos/5
        [HttpGet("GetCarritoByUsuario")]
        [Authorize]
     //   [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<List<Carrito>>> GetCarritosByUsuario(long idUsuario)
        {
         
            

            var carritoP = (from cp in _context.CarritoProducto
                            join p in _context.Producto on cp.IdProducto equals p.Id 
                            join c in _context.Carrito on  cp.IdCarrito equals c.Id 
                            join col in _context.Color on p.IdColor equals col.Id
                            join tal in _context.Talle on p.IdTalle equals tal.Id
                            where c.Id == idUsuario
                            select new CarritoProducto
                            {
                                Id=cp.Id,
                                IdCarrito = cp.IdCarrito,
                                Cantidad = cp.Cantidad,
                                Precio = cp.Precio,
                                IdProducto = cp.IdProducto,
                             //   IdCarritoNavigation=cp.IdCarrito,
                                IdProductoNavigation = new Producto() {
                                    Id = p.Id,
                                    Descripcion = p.Descripcion,
                                    IdColor = p.IdColor,
                                    IdColorNavigation=new Color() { 
                                        Id=p.IdColor,
                                        Descripcion=col.Descripcion,
                                        valor = col.valor
                                    },
                                    IdTalle = p.IdTalle,
                                    IdTalleNavigation=new Talle() { 
                                        Id=p.IdTalle,
                                        Descripcion=tal.Descripcion
                                    }
                                }
                            }).ToList();


            var resultado = (from ca in _context.Carrito //join 
                             //cp in  _context.CarritoProducto on  
                             //ca.Id equals cp.IdCarrito 
                             where ca.IdUsuario == idUsuario

                             select new Carrito
                             {
                                 Id = ca.Id,
                                 Total = ca.Total,
                                 Fecha = ca.Fecha,
                                 CantProductos = ca.CantProductos,
                                 IdEstadoCarrito = ca.IdEstadoCarrito == null ? 0 : ca.IdEstadoCarrito,

                                 IdComprobante = ca.IdComprobante == null ? 0 : ca.IdComprobante,
                                 IdUsuario = ca.IdUsuario,
                                 CarritoProductos = carritoP,

                             }).ToList();

        
            
            return resultado;
        }

        // PUT: api/Carritos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(long id, Carrito carrito)
        {
            if (id != carrito.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CarritoExists(id)==0)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Carritos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostCarrito")]
        [Authorize]
        public async Task<ActionResult<Carrito>> PostCarrito([FromBody] Carrito carrito)
        {
            _context.Carrito.Add(carrito);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { 
            Console.Write(e.Message);
            }
            
            return CreatedAtAction("GetCarrito", new { id = carrito.Id }, carrito);
        }

        // DELETE: api/Carritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrito(long id)
        {
            var carrito = await _context.Carrito.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.Carrito.Remove(carrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        
        [HttpGet("CarritoExists")]
        [Authorize]
        public long CarritoExists(long idUsuario)
        {
            if (_context.Carrito.Where(s => s.IdUsuario == idUsuario && s.IdEstadoCarrito == 1).Count() == 0)
                return 0;
            else
                return _context.Carrito.Where(s => s.IdUsuario == idUsuario && s.IdEstadoCarrito == 1).FirstOrDefault().Id;//.Any(e => e.Id == id);
        }


        //private  Task<IActionResult> CambiarEstadoCarrito(long id,Carrito carrito) {
         
        //    return null;
        //}



        [HttpPut("ConfirmarCarrito")]
        public async Task<IActionResult> ConfirmarCarrito(long id, [FromBody] Carrito carrito)
        {
            if (id != carrito.Id)
            {
                return BadRequest();
            }

            if (carrito.IdEstadoCarrito == 1)//si carrito abierto paso a carrito pendiente
            {
                carrito.IdEstadoCarrito = 2;
            }
            else
            {
                if (carrito.IdEstadoCarrito == 2)//si carrito esta pendiente  paso a carrito Completado
                {
                    carrito.IdEstadoCarrito = 3;
                }
            }
            _context.Entry(carrito).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
