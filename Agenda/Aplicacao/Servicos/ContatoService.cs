using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;

namespace Aplicacao.Servicos
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository,
            IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task AdicionaContatoAsync(ContatoDto contatoDto)
        {
            var contato = _mapper.Map<Contato>(contatoDto);
            await _contatoRepository.AdicionaContatoAsync(contato);

            await _contatoRepository.Salva();
        }

        public async Task AtualizaContatoAsync(ContatoDto contatoDto)
        {
            var contato = await _contatoRepository.BuscaContatoPorId(contatoDto.Id)
                    ?? throw new Exception("O Contato foi foi encontrado na base de dados");

            await _contatoRepository.AtualizaContatoAsync(contato);
            await _contatoRepository.Salva();
        }

        public async Task<IList<ContatoDto>> BuscaContatosAsync()
        {
            var contatos = await _contatoRepository.BuscaContatosAsync();
            var contatosDto = contatos.Select(e => _mapper.Map<ContatoDto>(e)).ToList();
            return contatosDto;
        }

        public async Task<IList<ContatoDto>> BuscaContatosPorNomeAsync(string nome)
        {
            var contatos = await _contatoRepository.BuscaContatosPorNomeAsync(nome);
            var contatosDto = contatos.Select(e => _mapper.Map<ContatoDto>(e)).ToList();
            return contatosDto;
        }

        public async Task RemoveContatoAsync(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                var contato = await _contatoRepository.BuscaContatoPorId(guid)
                    ?? throw new Exception("O Contato foi foi encontrado na base de dados");

                await _contatoRepository.AtualizaContatoAsync(contato);
                await _contatoRepository.Salva();
            }
            else
            {
                throw new Exception($"O id informado [{id}] é inválido");
            }
        }
    }
}
