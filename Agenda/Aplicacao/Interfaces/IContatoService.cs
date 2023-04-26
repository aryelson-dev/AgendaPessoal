using Aplicacao.Dtos;

namespace Aplicacao.Interfaces
{
    public interface IContatoService
    {
        Task<IList<ContatoDto>> BuscaContatosPorNomeAsync(string nome);
        Task<IList<ContatoDto>> BuscaContatosAsync();
        Task AdicionaContatoAsync(ContatoDto contato);
        Task AtualizaContatoAsync(ContatoDto contato);
        Task ExcluiContatoAsync(ContatoDto contato);
    }
}
