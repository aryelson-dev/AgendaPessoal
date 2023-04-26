using Domain.Entities;

namespace Aplicacao.Interfaces
{
    public interface ICorreiosService
    {
        Task<DadosCep> ConsultaCep(string cep);
    }
}
