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
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
      // [Authorize]
      //  [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<List<Producto>>> GetProducto()
        {
            List<Producto> listaProductos = _context.Producto.ToList();
            //List<Talle> listaTalles = _context.Talle.ToList();
            //List<Color> listaColores = _context.Color.ToList();
            //var productosAgrupados = listaProductos
            //    .GroupBy(p => p.Codigo)

            //    .Select(g => new Producto
            //    {
            //        Codigo = g.Key,
            //        Descripcion = (from p in _context.Producto where p.Codigo == g.Key select p).FirstOrDefault().Descripcion,
            //        Precio = (from p in _context.Producto where p.Codigo == g.Key select p).FirstOrDefault().Precio,

            //        IdMarca = (from p in _context.Producto join m in _context.Marca on p.IdMarca equals m.Id where p.Codigo == g.Key select m).FirstOrDefault().Id,
            //        IdRubro = (from p in _context.Producto join r in _context.Rubro on p.IdRubro equals r.Id where p.Codigo == g.Key select r).FirstOrDefault().Id,
            //        ListaTalles = (from lp in listaProductos
            //                       join lt in listaTalles on
            //                      lp.IdTalle equals lt.Id
            //                       where lp.Codigo == g.Key
            //                       select lt
            //                      ).Distinct().ToList(),
            //        ListaColores = (from lp in listaProductos
            //                        join lc in listaColores on
            //                       lp.IdColor equals lc.Id
            //                        where lp.Codigo == g.Key
            //                        select lc
            //                      ).Distinct().ToList()
            //    }).ToList();

            return listaProductos;//productosAgrupados;
        }




        [HttpGet("GetProductoByTCC")]
        // [Authorize]
        //  [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<Producto>> GetProductoByTCC(long talle, long color, string codigo)
        {
            Producto p = _context.Producto.Where(s=>s.IdTalle==talle && s.IdColor==color && s.Codigo==codigo).Include(s=>s.IdColorNavigation).Include(s => s.IdTalleNavigation).FirstOrDefault();
            return p;
        }




        //	[HttpGet]



        // GET: api/Productos/5
        //[HttpGet("{id}")]
        //      public async Task<ActionResult<Producto>> GetProducto(long id)
        //      {
        //          var producto = await _context.Producto.FindAsync(id);

        //          if (producto == null)
        //          {
        //              return NotFound();
        //          }

        //          return producto;
        //      }

        // PUT: api/Productos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(long id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(long id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(long id)
        {
            return _context.Producto.Any(e => e.Id == id);
        }
    }
}
