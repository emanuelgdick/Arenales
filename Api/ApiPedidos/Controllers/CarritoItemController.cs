using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace ApiPedidos.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoItemController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        private static IWebHostEnvironment _webHostEnvironment;
        public CarritoItemController(db_a6292f_pedidosContext _context, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = _context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<CarritoItem> lista = new List<CarritoItem>();

            try
            {
                lista = _dbcontext.CarritoItems.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }


        [HttpGet]
        [Route("Obtener/{idCarritoItem:int}")]
        public IActionResult Obtener(long idCarritoItem)
        {
            List<CarritoItem> oCarritoItem = _dbcontext.CarritoItems.Where(s => s.Id == idCarritoItem).ToList();

            if (oCarritoItem == null)
            {
                return BadRequest("CarritoItem no encontrada");

            }

            try
            {

                oCarritoItem = _dbcontext.CarritoItems.Where(p => p.Id == idCarritoItem).ToList();//.FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oCarritoItem });
                // return StatusCode(StatusCodes.Status200OK, new { oRubro });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oCarritoItem });


            }
        }








        //[HttpDelete]
        //[Route("Eliminar/{idCarritoItem:int}")]
        [HttpPut("Eliminar")]
        public ActionResult<CarritoItem> Eliminar(Int32 id)
        {
            CarritoItem oCarritoItem = _dbcontext.CarritoItems.Find(id);

            if (oCarritoItem == null)
            {
                return BadRequest("CarritoItem no encontrada");

            }

            try
            {

                _dbcontext.CarritoItems.Remove(oCarritoItem);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        

        [HttpPut]
        [Route("Editar")]
        public async Task<CarritoItem> Editar([FromBody] CarritoItem objeto)
        {
            CarritoItem oCarritoItem = _dbcontext.CarritoItems.Find(objeto.Id);


            CarritoItem r = new CarritoItem();
            oCarritoItem.oProducto.Descripcion = objeto.oProducto.Descripcion is null ? oCarritoItem.oProducto.Descripcion : objeto.oProducto.Descripcion;
            oCarritoItem.oProducto.Imagen = "Images/CarritoItems/" + oCarritoItem.Id.ToString() + ".webp";


            _dbcontext.CarritoItems.Update(oCarritoItem);
            _dbcontext.SaveChanges();
            r = _dbcontext.CarritoItems.Where(s => s.Id == objeto.Id).FirstOrDefault();
            return r;

        }

        [HttpPost]
        [Route("Guardar")]

        public async Task<CarritoItem> Crear([FromBody] CarritoItem CarritoItem)
        {
            CarritoItem r = new CarritoItem();
            long id = 0;
            _dbcontext.CarritoItems.Add(CarritoItem);
            _dbcontext.SaveChanges();
            id = _dbcontext.CarritoItems.OrderByDescending(u => u.Id).FirstOrDefault().Id;
            _dbcontext.CarritoItems.Where(s => s.Id == id).FirstOrDefault().oProducto.Imagen = "Images/CarritoItems/" + id.ToString() + ".webp";
            _dbcontext.SaveChanges();
            r = _dbcontext.CarritoItems.OrderByDescending(u => u.Id).FirstOrDefault();

            return r;
        }

    
    }
}
