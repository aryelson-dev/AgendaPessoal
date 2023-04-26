﻿using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> BuscaEnderecoPorId(Guid id);
        Task<IList<Endereco>> BuscaEnderecosAsync();
        Task AdicionaEnderecoAsync(Endereco Endereco);
        Task AtualizaEnderecoAsync(Endereco Endereco);
        Task ExcluiEnderecoAsync(Endereco Endereco);
        Task Salva();
    }
}