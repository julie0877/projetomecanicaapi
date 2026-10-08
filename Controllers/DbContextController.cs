using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetomecanicaapi.Models;

namespace projetomecanicaapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppContext : ControllerBase
    {
        private readonly DbContext _dbContext;
        public AppContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
    }

  public DbSet<usuarios> usuarios {  get; set; }
}
