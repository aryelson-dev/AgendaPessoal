using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestrutura.Contextos
{
    public class AgendaPessoalContext : DbContext
    {
        public AgendaPessoalContext(DbContextOptions<AgendaPessoalContext> options)
            : base(options)
        {
        }

        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
