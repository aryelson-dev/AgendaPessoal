using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Aplicacao.Servicos
{
    public class AgendaService : IAgendaService
    {
        private readonly IMapper _mapper;
        private readonly IContatoRepository _contatoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public AgendaService(IMapper mapper,
            IContatoRepository contatoRepository,
            IEnderecoRepository enderecoRepository)
        {
            _mapper = mapper;
            _contatoRepository = contatoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task AdicionaContatoAsync(ContatoDto contatoDto)
        {
            var contato = _mapper.Map<Contato>(contatoDto);
            await _contatoRepository.AdicionaContatoAsync(contato);

            var endereco = contato.Endereco;

            if (endereco != null && endereco.Cep > 0)
            {
                await _enderecoRepository.AdicionaEnderecoAsync(endereco);
            }

            await _contatoRepository.Salva();
        }

        public async Task AtualizaContatoAsync(ContatoDto contatoDto)
        {
            if (contatoDto == null || !contatoDto.Id.HasValue)
                throw new Exception("Dados inválidos");

            var contato = await _contatoRepository.BuscaContatoPorId(contatoDto.Id.Value)
                    ?? throw new Exception("O Contato foi foi encontrado na base de dados");

            var endereco = contato.Endereco;
            var haEnderecoParaAdicionar = endereco != null && endereco.Id.Equals(Guid.Empty) && endereco.Cep > 0;
            var haEnderecoParaAtualizar = endereco != null && !endereco.Id.Equals(Guid.Empty) && endereco.Cep > 0;

            if (haEnderecoParaAdicionar)
            {
                await _enderecoRepository.AdicionaEnderecoAsync(endereco);
            }

            if (haEnderecoParaAtualizar)
            {
                await _enderecoRepository.AtualizaEnderecoAsync(endereco);
            }

            await _contatoRepository.AtualizaContatoAsync(contato);
            await _contatoRepository.Salva();
        }

        public async Task<IList<ContatoDto>> BuscaContatosAsync()
        {
            var contatos = await _contatoRepository.BuscaContatosAsync();
            var contatosDto = contatos.Select(e => _mapper.Map<ContatoDto>(e))
                .OrderBy(e => e.Nome)
                .ToList();

            return contatosDto;
        }

        public async Task<IList<ContatoDto>> BuscaContatosPorNomeAsync(string nome)
        {
            var contatos = await _contatoRepository.BuscaContatosPorNomeAsync(nome);
            var contatosDto = contatos.Select(e => _mapper.Map<ContatoDto>(e))
                .OrderBy(e => e.Nome)
                .ToList();

            return contatosDto;
        }

        public async Task RemoveContatoAsync(string id)
        {
            if (Guid.TryParse(id, out Guid guid))
            {
                var contato = await _contatoRepository.BuscaContatoPorId(guid)
                    ?? throw new Exception("O Contato foi foi encontrado na base de dados");

                if(contato.Endereco != null)
                {
                    var endereco = await _enderecoRepository.BuscaEnderecoPorIdAsync(contato.Endereco.Id);
                    await _enderecoRepository.ExcluiEnderecoAsync(endereco);
                }
                
                await _contatoRepository.ExcluiContatoAsync(contato);
                await _contatoRepository.Salva();

            }
            else
            {
                throw new Exception($"O id informado [{id}] é inválido");
            }
        }
    }
}
