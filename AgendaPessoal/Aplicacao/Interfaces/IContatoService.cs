using Domain.Entities;

namespace Aplicacao.Interfaces
{
    public interface IContatoService
    {
        Task<IList<Contato>> BuscaContatosPorNomeAsync(string nome);
        Task<IList<Contato>> BuscaContatosAsync();
        Task AdicionaContatoAsync(Contato contato);
        Task AtualizaContatoAsync(Contato contato);
        Task ExcluiContatoAsync(Contato contato);
    }
}
