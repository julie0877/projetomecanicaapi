using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanicaapi.Controllers.Data;
using projetomecanicaapi.Models;

namespace projetomecanicaapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<cliente>>> GetClientes()
        {
            return await _context.clientes.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> CriarCliente(cliente cliente)
        {
            _context.Clientes.Add(cliente);

            await _context.SaveChangesAsync();
            return Ok("Cliente criado com sucesso!");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id, Clientes clientes)
        {
            var ClienteAtual = await _context.Clientes.FindAsync(id);
            if (ClienteAtual == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok("Cliente deletado com sucessor!");
        }
    }
}