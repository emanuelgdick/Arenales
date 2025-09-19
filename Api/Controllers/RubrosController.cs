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
    public class RubrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RubrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rubros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rubro>>> GetRubro()
        {
            return await _context.Rubro.ToListAsync();
        }

        // GET: api/Rubros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rubro>> GetRubro(long id)
        {
            var rubro = await _context.Rubro.FindAsync(id);

            if (rubro == null)
            {
                return NotFound();
            }

            return rubro;
        }

        // PUT: api/Rubros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRubro(long id, Rubro rubro)
        {
            if (id != rubro.Id)
            {
                return BadRequest();
            }

            _context.Entry(rubro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubroExists(id))
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

        // POST: api/Rubros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rubro>> PostRubro(Rubro rubro)
        {
            _context.Rubro.Add(rubro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRubro", new { id = rubro.Id }, rubro);
        }

        // DELETE: api/Rubros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRubro(long id)
        {
            var rubro = await _context.Rubro.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }

            _context.Rubro.Remove(rubro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RubroExists(long id)
        {
            return _context.Rubro.Any(e => e.Id == id);
        }
    }
}
