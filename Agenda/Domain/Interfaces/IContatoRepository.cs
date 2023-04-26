using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<IList<Contato>> BuscaContatosPorNomeAsync(string nome);
        Task<IList<Contato>> BuscaContatosAsync();
        Task AdicionaContatoAsync(Contato contato);
        Task AtualizaContatoAsync(Contato contato);
        Task ExcluiContatoAsync(Contato contato);
        Task Salva();
    }
}
