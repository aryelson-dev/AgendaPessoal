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

            var cepNumeros = cep.Replace("-", "").Replace(".", "");

            if (long.TryParse(cepNumeros, out long _cep) && _cep.ToString().Length == 8)
            {
                try
                {
                    var response = await correios.consultaCEPAsync(_cep.ToString());
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
                }
                catch (System.Exception)
                {
                }
            }

            return dadosCep;
        }
    }
}
