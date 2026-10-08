using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanicaapi.Models;

namespace projetomecanicaapi.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id, Veiculo veiculos)
        {
            var VeiculoAtual = await _context.Veiculos.FindAsync(id);
            if (VeiculoAtual == null)
            {
                return NotFound();
            }
            VeiculoAtual.Placa = veiculos.Placa;
            VeiculoAtual.Marca = veiculos.Marca;
            VeiculoAtual.ClienteId = veiculos.ClienteId;

            return Ok("Veiculo alterado com sucesso!");
        }
        [HttpPost]
        public async Task<ActionResult> CriarVeiculo(Veiculo veiculos)
        {
            _context.Veiculos.Add(veiculos);

            await _context.SaveChangesAsync();
            return Ok("Veiculo criado com sucesso!");
        }
        [HttpDelete]
        public async Task<ActionResult> DeletarVeiculo(int id)
        {
            var Veiculo = await _context.Veiculos.FindAsync(id);
            if (Veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(Veiculo);
            await _context.SaveChangesAsync();
            return Ok("Veiculo deletado com sucessor!");
        }
    }
}
