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
    public class ComprobanteItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComprobanteItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ComprobanteItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComprobanteItem>>> GetComprobanteItem()
        {
            return await _context.ComprobanteItem.ToListAsync();
        }

        // GET: api/ComprobanteItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComprobanteItem>> GetComprobanteItem(long id)
        {
            var comprobanteItem = await _context.ComprobanteItem.FindAsync(id);

            if (comprobanteItem == null)
            {
                return NotFound();
            }

            return comprobanteItem;
        }

        // PUT: api/ComprobanteItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComprobanteItem(long id, ComprobanteItem comprobanteItem)
        {
            if (id != comprobanteItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(comprobanteItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobanteItemExists(id))
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

        // POST: api/ComprobanteItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComprobanteItem>> PostComprobanteItem(ComprobanteItem comprobanteItem)
        {
            _context.ComprobanteItem.Add(comprobanteItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComprobanteItem", new { id = comprobanteItem.Id }, comprobanteItem);
        }

        // DELETE: api/ComprobanteItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComprobanteItem(long id)
        {
            var comprobanteItem = await _context.ComprobanteItem.FindAsync(id);
            if (comprobanteItem == null)
            {
                return NotFound();
            }

            _context.ComprobanteItem.Remove(comprobanteItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComprobanteItemExists(long id)
        {
            return _context.ComprobanteItem.Any(e => e.Id == id);
        }
    }
}
