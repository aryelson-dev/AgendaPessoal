using Domain.Entities;
using Domain.Interfaces;
using Infraestrutura.Contextos;

namespace Infraestrutura.Repositorios
{
    public class EnderecoRepository : MainRepository, IEnderecoRepository
    {
        private readonly AgendaContext _agendaPessoalContext;
        
        public EnderecoRepository(AgendaContext agendaPessoalContext)
            : base(agendaPessoalContext)
        {
            _agendaPessoalContext = agendaPessoalContext;
        }

        public async Task AdicionaEnderecoAsync(Endereco endereco)
        {
            await _agendaPessoalContext.Endereco.AddAsync(endereco);
        }

        public async Task AtualizaEnderecoAsync(Endereco endereco)
        {
            _agendaPessoalContext.Endereco.Update(endereco);
        }

        public Task<Endereco> BuscaEnderecoPorIdAsync(Guid id)
        {
            var result = _agendaPessoalContext.Endereco.FirstOrDefault(e => e.Id.Equals(id));
            return result != null ? Task.FromResult(result) : Task.FromResult(new Endereco());
        }

        public async Task<IList<Endereco>> BuscaEnderecosAsync()
        {
            return await Task.FromResult(_agendaPessoalContext.Endereco.ToList());
        }

        public async Task ExcluiEnderecoAsync(Endereco endereco)
        {
            _agendaPessoalContext.Endereco.Remove(endereco);
        }
    }
}
