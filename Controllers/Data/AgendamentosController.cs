using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanicaapi.Models;

namespace projetomecanicaapi.Controllers.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamentos>>> GetAgendamentos()
        {
            return await _context.Agendamentos.ToListAsync();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Alterar(int id, Agendamentos agendamentos)
        {
            var AgendamentoAtual = await _context.Agendamentos.FindAsync(id);
            if (AgendamentoAtual == null)
            {
                return NotFound();
            }
           AgendamentoAtual.Dia_Hora = agendamentos.Dia_Hora;
            AgendamentoAtual.ClienteId = agendamentos.ClienteId;

            return Ok("Agendamento alterado com sucesso!");
        }
        [HttpPost]
        public async Task<ActionResult> CriarAgendamento(Agendamentos agendamentos)
        {
            _context.Agendamentos.Add(agendamentos);

            await _context.SaveChangesAsync();
            return Ok("Agendamento feito com sucesso!");
        }
        [HttpDelete]
        public async Task<ActionResult> DeletarAgendamento(int id)
        {
            var Agendamento = await _context.Agendamentos.FindAsync(id);
            if (Agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(Agendamento);
            await _context.SaveChangesAsync();
            return Ok("Agendamento deletado com sucessor!");
        }
    }
}
