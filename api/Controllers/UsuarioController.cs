using api.Dal.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        public UsuarioController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get() => Ok(await appDbContext.usuario.ToListAsync());

        [HttpPost("Register")]
        public async Task<ActionResult<Usuario>> Register(RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null || string.IsNullOrWhiteSpace(registerUserDto.Email) ||
                string.IsNullOrWhiteSpace(registerUserDto.Nome) || string.IsNullOrWhiteSpace(registerUserDto.Senha))
            {
                return BadRequest("Invalid Request. Email, Nome, and Senha are required fields.");
            }

            if (registerUserDto.Senha != registerUserDto.ConfirmacaoDeSenha)
            {
                return BadRequest("Password and confirmation password do not match.");
            }

            var usuario = new Usuario
            {
                nome = registerUserDto.Nome,
                email = registerUserDto.Email,
                telefone = registerUserDto.Telefone,
                data_de_nascimento = registerUserDto.Data_de_Nascimento,
                senha = registerUserDto.Senha,
                nivel_acesso = 1 // ou qualquer valor padrão para o nível de acesso
            };

            appDbContext.usuario.Add(usuario);
            await appDbContext.SaveChangesAsync();
            return Ok(usuario);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Dto_Login>> Login(string email, string senha)
        {
            if (email is not null && senha is not null)
            {
                var usuario = await appDbContext.usuario
                    .FirstOrDefaultAsync(x => x.email.ToLower().Equals(email.ToLower()) && x.senha == senha);

                if (usuario == null)
                {
                    return NotFound("User not found");
                }

                var loginResponse = new Dto_Login
                {
                    Id = usuario.id,
                    Nome = usuario.nome,
                    Nivel_Acesso = usuario.nivel_acesso,
                    Data_de_Nascimento = usuario.data_de_nascimento,
                    Email = usuario.email,
                    Telefone = usuario.telefone
                };

                return Ok(loginResponse);
            }
            return BadRequest("Invalid Request");
        }
    }
}
