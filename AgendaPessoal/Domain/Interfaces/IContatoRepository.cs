using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<IList<Contato>> BuscaContatosPorNome(string nome);
        Task<IList<Contato>> BuscaContatos();
        Task AdicionaContato(Contato contato);
        Task AtualizaContato(Contato contato);
        Task ExcluiContato(Contato contato);
    }
}
