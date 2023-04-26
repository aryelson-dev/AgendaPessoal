using Aplicacao.Interfaces;
using Domain.Entities;
using Infraestrutura.Repositorios;

namespace Aplicacao.Servicos
{
    public class CorreiosService : ICorreiosService
    {
        public async Task<DadosCep> ConsultaCep(string cep)
        {
            return await CorreiosRepository.ConsultaCep(cep);
        }
    }
}
