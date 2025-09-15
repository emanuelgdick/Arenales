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
    public class CarritoProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarritoProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CarritoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarritoProducto>>> GetCarritoProducto()
        {
            return await _context.CarritoProducto.ToListAsync();
        }

        // GET: api/CarritoProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoProducto>> GetCarritoProducto(long id)
        {
            var carritoProducto = await _context.CarritoProducto.FindAsync(id);

            if (carritoProducto == null)
            {
                return NotFound();
            }

            return carritoProducto;
        }

        // PUT: api/CarritoProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PutCarritoProducto")]
        //[Authorize]
        public async Task<IActionResult> PutCarritoProducto(long id, [FromBody] CarritoProducto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            //int? cant = item.Cantidad;
            //int? cantBase = _context.CarritoProducto.AsNoTracking().Where(s => s.Id == item.Id).FirstOrDefault().Cantidad;

            //item.Cantidad = cantBase + cant;
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();


                Carrito carrito = _context.Carrito.Where(s => s.Id == item.IdCarrito).FirstOrDefault();
                List<CarritoProducto> items = _context.CarritoProducto.ToList();
                carrito.Total = items.Sum(it => it.Cantidad * it.Precio);
                _context.Entry(carrito).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarritoProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return CreatedAtAction("GetCarritoProducto", new { id = item.Id }, item);
        }



        [HttpPost("PostCarritoProducto")]
        [Authorize] 
        public async Task<ActionResult<CarritoProducto>> PostCarritoProducto([FromBody] CarritoProducto carritoProducto)
        {
            _context.CarritoProducto.Add(carritoProducto);
            await _context.SaveChangesAsync();
            List<CarritoProducto> items= _context.CarritoProducto.ToList();
            Carrito carrito = _context.Carrito.Where(s => s.Id == carritoProducto.IdCarrito).FirstOrDefault();
            carrito.Total = items.Sum(it => it.Cantidad * it.Precio);
            _context.Entry(carrito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCarritoProducto", new { id = carritoProducto.Id }, carritoProducto);
        }

        // DELETE: api/CarritoProductos/5
        //[HttpDelete("{id}")]
        [HttpPut("DeleteCarritoProducto")]
        [Authorize]
        public async Task<IActionResult> DeleteCarritoProducto(long id)
        {
            var carritoProducto =  _context.CarritoProducto.Where(s => s.Id == id).FirstOrDefault();//.FindAsync(id);
            if (carritoProducto == null)
            {
                return NotFound();
            }

            _context.CarritoProducto.Remove(carritoProducto);
            await _context.SaveChangesAsync();


            List<CarritoProducto> items = _context.CarritoProducto.ToList();

            Carrito carrito = _context.Carrito.Where(s => s.Id == carritoProducto.IdCarrito).FirstOrDefault();
            carrito.Total = items.Sum(it => it.Cantidad * it.Precio);
            _context.Entry(carrito).State = EntityState.Modified;
            await _context.SaveChangesAsync();




            return NoContent();
        }

        private bool CarritoProductoExists(long id)
        {
            return _context.CarritoProducto.Any(e => e.Id == id);
        }
    }
}
