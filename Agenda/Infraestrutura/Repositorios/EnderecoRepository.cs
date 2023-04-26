using Domain.Entities;
using Domain.Interfaces;
using Infraestrutura.Contextos;

namespace Infraestrutura.Repositorios
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AgendaPessoalContext _agendaPessoalContext;
        
        public EnderecoRepository(AgendaPessoalContext agendaPessoalContext)
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

        public Task<Endereco> BuscaEnderecoPorId(Guid id)
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

        public async Task Salva()
        {
            await _agendaPessoalContext.SaveChangesAsync();
        }
    }
}
