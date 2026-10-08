using Microsoft.EntityFrameworkCore;
using projetomecanicaapi.Models;

namespace projetomecanicaapi.Controllers.Data
{
    public class AppDbContext :DbContext
    {
        private readonly DbContext _dbContext;
        internal object clientes;

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Agendamentos> Agendamentos { get; set; }
    }
}
