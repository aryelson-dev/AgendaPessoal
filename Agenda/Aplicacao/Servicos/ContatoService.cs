using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

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
            var contato = _mapper.Map<Contato>(contatoDto);
            await _contatoRepository.AtualizaContatoAsync(contato);
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

        public async Task ExcluiContatoAsync(ContatoDto contato)
        {
            throw new NotImplementedException();
        }
    }
}
