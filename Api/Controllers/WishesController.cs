using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public WishesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Wishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wish>>> GetWish()
        {
            return await _context.Wish.ToListAsync();
        }

        // GET: api/Wishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wish>> GetWish(long id)
        {
            var wish = await _context.Wish.FindAsync(id);

            if (wish == null)
            {
                return NotFound();
            }

            return wish;
        }

        [HttpGet("GetWishByUsuario")]
        [Authorize]
        //   [ResponseCache(CacheProfileName = "apicache")]
        public async Task<ActionResult<List<Wish>>> GetWishByUsuario(long idUsuario)
        {

            var resultado = (from ca in _context.Wish 
                             join u in _context.Usuario on
                             ca.IdUsuario equals u.Id
                             join p in _context.Producto on
                             ca.IdProducto equals p.Id
                             join ta in _context.Talle on
                             p.IdTalle equals ta.Id 
                             join co in _context.Color on
                             p.IdColor equals  co.Id

                             where ca.IdUsuario == idUsuario
                             select new Wish
                             {
                                 Id = ca.Id,
                                 Producto =new Producto() { 
                                    Id =p.Id,
                                    IdColor=p.IdColor,
                                    IdColorNavigation=new Color() { 
                                        Id=co.Id,
                                        Descripcion=co.Descripcion,
                                        valor = co.valor
                                    },
                                    IdTalle = p.IdTalle,
                                    IdTalleNavigation = new Talle()
                                    {
                                       Id = ta.Id,
                                       Descripcion = ta.Descripcion
                                    },
                                    
                                    IdMarca=p.IdMarca,
                                    IdRubro=p.IdRubro,
                                    Descripcion=p.Descripcion,
                                    Precio=p.Precio
                                 },
                                 IdProducto = p.Id,
                                 Usuario = new Usuario(){ 
                                    Id=u.Id,
                                    ApeyNom = u.ApeyNom,
                                    User = u.User
                                 },
                                 IdUsuario = u.Id
                                
                             }).ToList();
            return resultado;
        }




        // PUT: api/Wishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWish(long id, Wish Wish)
        {
            if (id != Wish.Id)
            {
                return BadRequest();
            }

            _context.Entry(Wish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishExists(id))
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

        // POST: api/Wishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("PostWish")]
        public async Task<ActionResult<Wish>> PostWish([FromBody] Wish Wish)
        {
            _context.Wish.Add(Wish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWish", new { id = Wish.Id }, Wish);
        }

        // DELETE: api/Wishes/5
        [HttpPost("DeleteWish")]
        [Authorize]
        public async Task<IActionResult> DeleteWish(Wish wish)
        {
            var Wish =  _context.Wish.Where(s => s.IdUsuario == wish.IdUsuario && s.IdProducto==wish.IdProducto).FirstOrDefault();
            if (Wish == null)
            {
                return NotFound();
            }

            _context.Wish.Remove(Wish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishExists(long id)
        {
            return _context.Wish.Any(e => e.Id == id);
        }
    }
}
