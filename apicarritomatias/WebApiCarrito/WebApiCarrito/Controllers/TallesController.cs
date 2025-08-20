using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCarrito.Data;
using WebApiCarrito.Models;

namespace WebApiCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TallesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TallesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Talles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Talle>>> GetTalle()
        {
            return await _context.Talle.ToListAsync();
        }

        // GET: api/Talles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Talle>> GetTalle(long id)
        {
            var talle = await _context.Talle.FindAsync(id);

            if (talle == null)
            {
                return NotFound();
            }

            return talle;
        }

        // PUT: api/Talles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTalle(long id, Talle talle)
        {
            if (id != talle.Id)
            {
                return BadRequest();
            }

            _context.Entry(talle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TalleExists(id))
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

        // POST: api/Talles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Talle>> PostTalle(Talle talle)
        {
            _context.Talle.Add(talle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTalle", new { id = talle.Id }, talle);
        }

        // DELETE: api/Talles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTalle(long id)
        {
            var talle = await _context.Talle.FindAsync(id);
            if (talle == null)
            {
                return NotFound();
            }

            _context.Talle.Remove(talle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TalleExists(long id)
        {
            return _context.Talle.Any(e => e.Id == id);
        }
    }
}
