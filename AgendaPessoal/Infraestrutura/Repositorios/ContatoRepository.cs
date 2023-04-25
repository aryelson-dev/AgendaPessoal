using Domain.Entities;
using Domain.Interfaces;

namespace Infraestrutura.Repositorios
{
    internal class ContatoRepository : IContatoRepository
    {
        public Task AdicionaContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task AtualizaContato(Contato contato)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contato>> BuscaContatos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Contato>> BuscaContatosPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task ExcluiContato(Contato contato)
        {
            throw new NotImplementedException();
        }
    }
}
