using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCarritosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadoCarritosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCarritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCarrito>>> GetEstadoCarrito()
        {
            return await _context.EstadoCarrito.ToListAsync();
        }

        // GET: api/EstadoCarritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCarrito>> GetEstadoCarrito(long id)
        {
            var estadoCarrito = await _context.EstadoCarrito.FindAsync(id);

            if (estadoCarrito == null)
            {
                return NotFound();
            }

            return estadoCarrito;
        }

        // PUT: api/EstadoCarritos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCarrito(long id, EstadoCarrito estadoCarrito)
        {
            if (id != estadoCarrito.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoCarrito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCarritoExists(id))
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

        // POST: api/EstadoCarritos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoCarrito>> PostEstadoCarrito(EstadoCarrito estadoCarrito)
        {
            _context.EstadoCarrito.Add(estadoCarrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCarrito", new { id = estadoCarrito.Id }, estadoCarrito);
        }

        // DELETE: api/EstadoCarritos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCarrito(long id)
        {
            var estadoCarrito = await _context.EstadoCarrito.FindAsync(id);
            if (estadoCarrito == null)
            {
                return NotFound();
            }

            _context.EstadoCarrito.Remove(estadoCarrito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCarritoExists(long id)
        {
            return _context.EstadoCarrito.Any(e => e.Id == id);
        }
    }
}
