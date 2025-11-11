//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;
using Api;
using Api.Models;
using Api;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private AppDbContext _db;
        private string _SecretKey;

        public UsuariosController(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        [HttpPost("UserLogin")]
        public async Task<LoginResponseDTO> Login( LoginRequestDTO logindetails)
        {
            //int cantidad = _db.Usuario.Count();
           
           //try {
            var user = _db.Usuario.FirstOrDefault(u => u.User.ToLower() == logindetails.User.ToLower()
            && u.Password.ToLower() == RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));//logindetails.Password.ToLower());

            //   } catch (Exception e) { Console.WriteLine(e.Message); }
            //return null;
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                  //  new Claim(ClaimTypes.Role, user.Rol),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = user,
            };

            return loginResponse;
        }

        // GET: api/usuario/5
        [HttpGet("GetUsuarioByEmail")]
        // [Authorize]
        public async Task<ActionResult<Usuario>> GetUsuarioByEmail(string email)
        {
            var usuario = _db.Usuario.Where(s => s.User == email).FirstOrDefault();
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
           
        }



        [HttpPost("AddUser")]
        public async Task<ActionResult<Usuario>> AddUser([FromBody] RegisterRequestDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return null;//BadRequest(ModelState);
            }
            Usuario u = new Usuario();
            // u.Rol = usuario.Rol;
            u.ApeyNom = usuario.ApeyNom;
            u.User = usuario.User;
            u.IdLocalidad = usuario.IdLocalidad;
            u.Direccion = usuario.Direccion;
            u.Telefono = usuario.Telefono;

            u.Password =  RecursosBiz.ConvertirSha256(usuario.Password);//usuario.Password;//

            var c = _db.Usuario.Where(x => x.User == usuario.User).Count();

            if (c == 0)
            {
                _db.Usuario.Add(u);
                try {

                    await _db.SaveChangesAsync();
                } catch (Exception e) { Console.WriteLine(e.Message); }
                
                return Ok(u);
            }
            else
            {
                return null;
            }
        }


        [HttpPost("Reestablecer")]
        public async Task<ActionResult> Reestablecer(Usuario usuario)
        {
            string nuevaclave = RecursosBiz.GenerarClave();
            //ReestablecerClave(usuario.Id, RecursosBiz.ConvertirSha256(nuevaclave));
            var @event = await _db.Usuario.SingleOrDefaultAsync(m => m.Id == usuario.Id);
            if (@event == null)
            {
                return NotFound();
            }
            @event.Password = RecursosBiz.ConvertirSha256(nuevaclave);

            try
            {
                await _db.SaveChangesAsync();
                string asunto = "Crontraseña Reestablecida";
                string mensaje_correo = "<h3>Su Cuenta fue reestablecida correctamente </h3></br><p>Su contraseña para acceder ahora es: !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", nuevaclave);
                bool respuesta = RecursosBiz.EnviarCorreo(usuario.User, asunto, mensaje_correo);
                return Ok();
            }
            catch (Exception ex) {
                return NoContent();
            }

            

            
            
        }

        
        
        [HttpPost("ActualizarDatos")]
        //[Authorize]
        public ActionResult<Usuario> ActualizarDatos(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(usuario);
            }

            var Usuario = _db.Usuario.FirstOrDefault(x => x.Id == id);
            if (Usuario == null)
            {
                return NotFound();
            }

            Usuario.Telefono = usuario.Telefono;
            Usuario.Direccion = usuario.Direccion;
            Usuario.ApeyNom = usuario.ApeyNom;
            _db.SaveChanges();
            return Ok(Usuario);

        }



        //public  void ReestablecerClave(long idusuario, string clave/*, out string Mensaje*/)
        //{
        //    bool resultado = false;

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var @event = await _db.Usuario.SingleOrDefaultAsync(m => m.Id == idusuario);
        //    if (@event == null)
        //    {
        //        return NotFound();
        //    }
        //    @event.Password = clave;

        //    try
        //    {
        //        await _db.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {

        //            throw;
        // return NoContent();
        //    }



        //}


    }
}
