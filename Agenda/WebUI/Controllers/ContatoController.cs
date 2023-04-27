using Aplicacao.Dtos;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IAgendaService _contatoService;

        public ContatoController(IAgendaService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> ListaContatosAsync()
        {
            return Ok(await _contatoService.BuscaContatosAsync());
        }

        [HttpGet("lista/{id}")]
        public async Task<IActionResult> ListaContatosPorIdAsync([FromRoute] string id)
        {
            return Ok(await _contatoService.BuscaContatosPorIdAsync(id));
        }

        [HttpPost("adiciona")]
        public async Task AdicionaContatoAsync([FromBody] ContatoDto contato)
        {
            await _contatoService.AdicionaContatoAsync(contato);
        }

        [HttpPut("atualiza")]
        public async Task AtualizaContatoAsync([FromBody] ContatoDto contato)
        {
            await _contatoService.AtualizaContatoAsync(contato);
        }

        [HttpDelete("remove/{id}")]
        public async Task RemoveContatoAsync([FromRoute] string id)
        {
            await _contatoService.RemoveContatoAsync(id);
        }
    }
}
