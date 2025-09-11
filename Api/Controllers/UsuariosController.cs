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
            int cantidad = _db.Usuario.Count();

            var user = _db.Usuario.FirstOrDefault(u => u.User.ToLower() == logindetails.User.ToLower()
            && u.Password.ToLower() == RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));


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


        [HttpPost("AddUser")]
        public async Task<ActionResult<Usuario>> AddUser([FromBody] LoginRequestDTO usuario)
        {
            if (!ModelState.IsValid)
            {
                return null;//BadRequest(ModelState);
            }
            Usuario u = new Usuario();
           // u.Rol = usuario.Rol;
            u.ApeyNom = usuario.ApeyNom;
            u.User = usuario.User;
            u.Password = RecursosBiz.ConvertirSha256(usuario.Password);
            _db.Usuario.Add(u);
            try { _db.SaveChanges(); } catch (Exception e){ Console.Write(e.Message); }
            
            return Ok(u);

        }

    }
}
