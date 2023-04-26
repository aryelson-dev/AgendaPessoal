using Domain.Entities;
using Domain.Interfaces;
using Infraestrutura.Contextos;

namespace Infraestrutura.Repositorios
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AgendaPessoalContext _agendaPessoalContext;
        public ContatoRepository(AgendaPessoalContext agendaPessoalContext)
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

        public async Task<IList<Contato>> BuscaContatosAsync()
        {
            return await Task.FromResult(_agendaPessoalContext.Contato.ToList());
        }

        public async Task<IList<Contato>> BuscaContatosPorNomeAsync(string nome)
        {
            return await Task.FromResult(_agendaPessoalContext.Contato.Where(e => e.Nome.ToLower().Contains(nome)).ToList());
        }

        public async Task ExcluiContatoAsync(Contato contato)
        {
            _agendaPessoalContext.Contato.Remove(contato);
        }
    }
}
