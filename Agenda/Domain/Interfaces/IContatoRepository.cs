using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> BuscaContatoPorIdAsync(Guid id);
        Task<IList<Contato>> BuscaContatosAsync();
        Task AdicionaContatoAsync(Contato contato);
        Task AtualizaContatoAsync(Contato contato);
        Task ExcluiContatoAsync(Contato contato);
        Task Salva();
    }
}
