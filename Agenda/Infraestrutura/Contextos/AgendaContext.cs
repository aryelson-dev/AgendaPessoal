using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestrutura.Contextos
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options)
            : base(options)
        {
        }

        public DbSet<Contato> Contato { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
