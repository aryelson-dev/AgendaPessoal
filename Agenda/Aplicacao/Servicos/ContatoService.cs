using Aplicacao.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplicacao.Servicos
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public Task AdicionaContatoAsync(Contato contato)
        {
            return _contatoRepository.AdicionaContatoAsync(contato);
        }

        public Task AtualizaContatoAsync(Contato contato)
        {
            return _contatoRepository.AtualizaContatoAsync(contato);
        }

        public Task<IList<Contato>> BuscaContatosAsync()
        {
            return _contatoRepository.BuscaContatosAsync();
        }

        public Task<IList<Contato>> BuscaContatosPorNomeAsync(string nome)
        {
            return _contatoRepository.BuscaContatosPorNomeAsync(nome);
        }

        public Task ExcluiContatoAsync(Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
