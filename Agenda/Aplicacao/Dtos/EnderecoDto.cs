namespace Aplicacao.Dtos
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public long Cep { get; set; }
        public string Rua { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
