using Infraestrutura.Contextos;

namespace Infraestrutura.Repositorios
{
    public abstract class MainRepository
    {
        private readonly AgendaContext _agendaContext;
        public MainRepository(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        public async Task Salva()
        {
            await _agendaContext.SaveChangesAsync();
        }
    }
}
