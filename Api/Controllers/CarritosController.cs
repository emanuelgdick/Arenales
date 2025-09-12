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
        [HttpGet("GetCarritoByCliente")]
        [Authorize]
     //   [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<Carrito>> GetCarritoByCliente(long idCliente)
        {
            //////var carrito = await _context.Carrito.FindAsync(idCliente);

            //////if (carrito == null)
            //////{
            //////    return null;//NotFound();
            //////}

            //////return carrito;




            //  var carrito = _db.Carrito.Where(s=>s.IdCliente==idCliente).ToList();



            // Realizar la unión utilizando Join
            //var resultado = from car in carrito
            //                select new
            //                {
            //                    Id = car.Id,
            //                    Total=car.Total,
            //                    Fecha=car.Fecha,
            //                    Nro=car.Nro,
            //                    idCliente=car.IdCliente,
            //                    CarritoProductos =new CarritoProducto{ 



            //}


            //                };
            //return Ok(resultado);



            //List<Carrito> carritos = await _context.Carrito.Where(s => s.IdCliente == idCliente).ToListAsync();
            //List<CarritoProducto> carritoProducto = await _context.CarritoProducto.Where(d => d.IdCarrito == 1).ToListAsync();
            //List<Producto> producto = (from p in  _context.Producto join
            //                          cp in carritoProducto  on p.Id equals cp.IdProducto
            //                          select p).ToList();






            //       await _context.CarritoProducto.Where(d => d.IdCarrito == 1).ToListAsync();


            var carritoP = (from cp in _context.CarritoProducto
                            join p in _context.Producto on cp.IdProducto equals p.Id
                            where cp.IdCarrito == 1
                            select new CarritoProducto
                            {
                                IdCarrito = cp.IdCarrito,
                                Cantidad = cp.Cantidad,
                                Precio = cp.Precio,
                                IdProducto = cp.IdProducto,
                             //   IdCarritoNavigation=cp.IdCarrito,
                                IdProductoNavigation = new Producto() {
                                    Id = p.Id,
                                    Descripcion = p.Descripcion
                                }
                            }).ToList();


            var resultado = (from m in _context.Carrito
                             from cp in _context.CarritoProducto
                             where cp.IdCarrito == m.Id
                             select new Carrito
                             {
                                 Id = m.Id,
                                 Total = m.Total,
                                 Fecha = m.Fecha,
                                 Numero = m.Numero,
                                 IdEstadoCarrito = m.IdEstadoCarrito == null ? 0 : m.IdEstadoCarrito,

                                 IdComprobante = m.IdComprobante == null ? 0 : m.IdComprobante,
                                 IdCliente = m.IdCliente,
                                 CarritoProductos = carritoP,

                             }).FirstOrDefault();

        
            
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
                if (!CarritoExists(id))
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

        private bool CarritoExists(long id)
        {
            return _context.Carrito.Any(e => e.Id == id);
        }
    }
}
