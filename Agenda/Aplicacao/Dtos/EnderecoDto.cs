using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o cep")]
        public long Cep { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o estado")]
        public string Estado { get; set; }
    }
}
