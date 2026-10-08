using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecaniaApi.Controllers;
using projetomecanicaapi.Controllers.Data;



namespace ProjetoMecaniaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Login(UsuariosController usuarios)
        {
            var user = _appDbContext.Usuarios.FirstOrDefault(u => u.Nome == usuarios.Nome && u.Senha == usuarios.Senha);

            if (user == null)
            {
                return Unauthorized("Credenciais invàlidas!");
            }

            return Ok(new { Nome = user.Nome });
        }
    }
}
  
