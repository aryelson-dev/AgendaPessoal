using Domain.Entities;
using Domain.Interfaces;
using Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios
{
    public class ContatoRepository : MainRepository, IContatoRepository
    {
        private readonly AgendaContext _agendaPessoalContext;

        public ContatoRepository(AgendaContext agendaPessoalContext)
            : base(agendaPessoalContext)
        {
            _agendaPessoalContext = agendaPessoalContext;
        }

        public async Task AdicionaContatoAsync(Contato contato)
        {
            await _agendaPessoalContext.Contato.AddAsync(contato);
        }

        public async Task AtualizaContatoAsync(Contato contato)
        {
            _agendaPessoalContext.Contato.Update(contato);
        }

        public Task<Contato> BuscaContatoPorIdAsync(Guid id)
        {
            var result = _agendaPessoalContext.Contato
                .Include(e => e.Endereco)
                .FirstOrDefault(e => e.Id.Equals(id));

            return result != null ? Task.FromResult(result) : Task.FromResult(new Contato());
        }

        public async Task<IList<Contato>> BuscaContatosAsync()
        {
            return await Task.FromResult(_agendaPessoalContext.Contato
                .Include(e => e.Endereco)
                .ToList());
        }

        public async Task ExcluiContatoAsync(Contato contato)
        {
            _agendaPessoalContext.Contato.Remove(contato);
        }
    }
}
