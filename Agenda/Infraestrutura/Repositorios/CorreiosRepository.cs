using CorreiosSoapServices;
using Domain.Entities;

namespace Infraestrutura.Repositorios
{
    public class CorreiosRepository
    {
        public static async Task<DadosCep> ConsultaCep(string cep)
        {
            var correios = new AtendeClienteClient();
            var dadosCep = new DadosCep();

            var response = await correios.consultaCEPAsync(cep.Replace("-", ""));
            if (response != null)
            {
                dadosCep = new DadosCep()
                {
                    Cep = response.@return.cep,
                    Rua = response.@return.end,
                    Bairro = response.@return.bairro,
                    Cidade = response.@return.cidade,
                    Estado = response.@return.uf
                };
            }

            return dadosCep;
        }
    }
}
