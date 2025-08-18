using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using ApiPedidos.Models;

using Microsoft.AspNetCore.Cors;

namespace ApiPedidos.Controllers
{

    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        public readonly db_a6292f_pedidosContext _dbcontext;

        public VendedorController(db_a6292f_pedidosContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Vendedor> lista = new List<Vendedor>();

            try
            {
                lista = _dbcontext.Vendedors.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });

            }
        }

        [HttpGet]
        [Route("Obtener/{idVendedor:int}")]
        public IActionResult Obtener(int idVendedor)
        {
            Vendedor oVendedor = _dbcontext.Vendedors.Find(idVendedor);

            if (oVendedor == null)
            {
                return BadRequest("Vendedor no encontrado");

            }

            try
            {

                oVendedor = _dbcontext.Vendedors.Where(p => p.Id == idVendedor).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oVendedor });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oVendedor });


            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Vendedor objeto)
        {


            try
            {
                _dbcontext.Vendedors.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }




        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Vendedor objeto)
        {
            Vendedor oVendedor = _dbcontext.Vendedors.Find(objeto.Id);

            if (oVendedor == null)
            {
                return BadRequest("Vendedor no encontrada");

            }

            try
            {
              //  oVendedor.Descripcion = objeto.Descripcion is null ? oVendedor.Descripcion : objeto.Descripcion;

                oVendedor.Nombre = objeto.Nombre is null ? oVendedor.Nombre : objeto.Nombre;
                oVendedor.Apellido = objeto.Apellido is null ? oVendedor.Apellido : objeto.Apellido;
                oVendedor.Calle = objeto.Calle is null ? oVendedor.Calle : objeto.Calle;
                oVendedor.Legajo = objeto.Legajo is null ? oVendedor.Legajo : objeto.Legajo;
                oVendedor.Numero = objeto.Numero is null ? oVendedor.Numero : objeto.Numero;
                oVendedor.Cuit = objeto.Cuit is null ? oVendedor.Cuit : objeto.Cuit;
                oVendedor.Depto = objeto.Depto is null ? oVendedor.Depto : objeto.Depto;
                oVendedor.Email = objeto.Email is null ? oVendedor.Email : objeto.Email;
                oVendedor.Piso = objeto.Piso is null ? oVendedor.Piso : objeto.Piso;
                oVendedor.TelefonoFijo = objeto.TelefonoFijo is null ? oVendedor.TelefonoFijo : objeto.TelefonoFijo;
                oVendedor.TelefonoMovil = objeto.TelefonoMovil is null ? oVendedor.TelefonoMovil : objeto.TelefonoMovil;
                oVendedor.Torre = objeto.Torre is null ? oVendedor.Torre : objeto.Torre;
                oVendedor.Observaciones = objeto.Observaciones is null ? oVendedor.Observaciones : objeto.Observaciones;



                _dbcontext.Vendedors.Update(oVendedor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("Eliminar/{idVendedor:int}")]
        public IActionResult Eliminar(int idVendedor)
        {

            Vendedor oVendedor = _dbcontext.Vendedors.Find(idVendedor);

            if (oVendedor == null)
            {
                return BadRequest("Vendedor no encontrada");

            }

            try
            {

                _dbcontext.Vendedors.Remove(oVendedor);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }
    }
}
