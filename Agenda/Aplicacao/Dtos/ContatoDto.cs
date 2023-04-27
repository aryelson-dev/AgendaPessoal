using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Dtos
{
    public class ContatoDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        public string? Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? Email { get; set; }
        public string? DataNascimento { get; set; }

        public EnderecoDto? Endereco { get; set; }
    }
}
