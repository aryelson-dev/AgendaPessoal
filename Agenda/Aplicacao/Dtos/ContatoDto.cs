namespace Aplicacao.Dtos
{
    public class ContatoDto
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string? Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? Email { get; set; }
        public string? DataNascimento { get; set; }

        public EnderecoDto? Endereco { get; set; }
    }
}
