using Infraestrutura.Contextos;

namespace Infraestrutura.Repositorios
{
    public abstract class MainRepository
    {
        private readonly AgendaPessoalContext _agendaPessoalContext;
        public MainRepository(AgendaPessoalContext agendaPessoalContext)
        {
            _agendaPessoalContext = agendaPessoalContext;
        }

        public async Task Salva()
        {
            await _agendaPessoalContext.SaveChangesAsync();
        }
    }
}
