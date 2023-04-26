namespace Domain.Entities
{
    public class Contato
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }

        public Endereco? Endereco { get; set; }
    }
}
