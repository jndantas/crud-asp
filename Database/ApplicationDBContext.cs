using Microsoft.EntityFrameworkCore;
using efcurso.Models;

namespace efcurso.Database
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios {get; set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}