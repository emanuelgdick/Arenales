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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ActionResult<List<Producto>>> GetProducto(int pageSize, int pageNumber,int arenales)
        {
            var productosAgrupados = (from pi in _context.ProductoImagen
                                      join
                                  p in _context.Producto on pi.IdProducto equals p.Id
                                      join
                                  m in _context.Marca on p.IdMarca equals m.Id
                                      where (m.Mostrar == true) && ((p.IdMarca == 128800744 && arenales == 1) || (arenales == 0 && p.IdMarca != 128800744))
                                      select p).ToList()
             .GroupBy(p => p.Codigo)
             .Select(g => new //Producto
             {

                 Codigo = g.Key,
                 Id = g.First().Id,
                 Description = g.First().Descripcion,
                 Precio = g.First().Precio,
                 ListaColores = g.Select(p => p.IdColor).Distinct().ToList(), // Obtiene colores únicos
                 ListaTalles = g.Select(p => p.IdTalle).Distinct().ToList(), // Obtiene talles únicos
                 ListaIds = g.Select(p => p.Id).Distinct().ToList(), // Obtiene ids para las fotos
             }).ToList().OrderBy(p => p.Codigo);

            List<Producto> listaproducto = new List<Producto>();
            var listaColor = _context.Color.ToList();
            var listaTalle = _context.Talle.ToList();
            var listaImagen = _context.ProductoImagen.ToList();
            foreach (var p in productosAgrupados)
            {
                Producto prod = new Producto();
                prod.Id = p.Id;
                prod.Codigo = p.Codigo.ToString();
                prod.Descripcion = p.Description;
                prod.Precio = p.Precio;

                foreach (var item in p.ListaColores.ToList())
                {

                    Color color = new Color()
                    {
                        Id = item,
                        Descripcion = listaColor.Where(s => s.Id == item).FirstOrDefault().Descripcion
                    };
                    prod.ListaColores.Add(color);
                }
                foreach (var item2 in p.ListaTalles.ToList())
                {

                    Talle talle = new Talle()
                    {
                        Id = item2,
                        Descripcion = listaTalle.Where(s => s.Id == item2).FirstOrDefault().Descripcion,

                    };
                    prod.ListaTalles.Add(talle);
                }
                foreach (var item3 in p.ListaIds.ToList())
                {
                    if (listaImagen.Where(s => s.IdProducto == item3).Count() != 0)
                    {
                        List<ProductoImagen> prodImagen = new List<ProductoImagen>();
                        prodImagen = listaImagen.Where(s => s.IdProducto == item3).ToList();
                        foreach (var a in prodImagen)
                        {

                            a.IdProductoNavigation = null;
                        }
                        prod.ProductoImagens = prodImagen;

                    }
                }

                listaproducto.Add(prod);
            }
            return listaproducto

            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();


            //var productos = (from pi in _context.ProductoImagen
            //                 join
            //             p in _context.Producto on pi.IdProducto equals p.Id
            //                 join
            //             m in _context.Marca on p.IdMarca equals m.Id
            //                 where (m.Mostrar == true) && ((p.IdMarca == 128800744 && arenales == 1) || (arenales == 0))
            //                 select p).ToList();
            //return Ok(productos);


        }




        [HttpGet("GetProductoByTCC")]
        // [Authorize]
        //  [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<Producto>> GetProductoByTCC( long talle, long color, string codigo)
        {







            //Producto prod = (from pi in _context.ProductoImagen
            //                 join p in _context.Producto on pi.IdProducto equals p.Id
            //                 where (p.IdTalle == talle) && (p.IdColor == color) && (p.Codigo == codigo)
            //                 select  p).FirstOrDefault();

            Producto prod = _context.Producto.Where(s => s.IdTalle == talle && s.IdColor == color && s.Codigo == codigo).Include(s => s.IdColorNavigation).Include(s => s.IdTalleNavigation).Include(s => s.ProductoImagens).FirstOrDefault();
            
            //var imagen = _context.ProductoImagen.Where(s => s.IdProducto == prod.Id).FirstOrDefault();
            //prod.ProductoImagens.Add(imagen);
            if (prod.ProductoImagens.Count() == 0) {

                var idproducto = (from p in _context.Producto
                                  join pi in _context.ProductoImagen on
                                  p.Id equals pi.IdProducto
                                  where p.Codigo == codigo
                                  select pi).FirstOrDefault().IdProducto;

               
                prod.ProductoImagens = _context.ProductoImagen.Where(s => s.IdProducto == idproducto).ToList();

            }


            return prod;
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
