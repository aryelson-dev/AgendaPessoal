using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet("contatos")]
        public async Task<IActionResult> ListaContatosAsync()
        {
            return Ok(await _contatoService.BuscaContatosAsync());
        }

        [HttpGet("contatos/{nome}")]
        public async Task<IActionResult> ListaContatosPorNomeAsync([FromRoute] string nome)
        {
            return Ok(await _contatoService.BuscaContatosPorNomeAsync(nome));
        }
    }
}
