using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CorreiosController : ControllerBase
    {
        private readonly ICorreiosService _correiosService;

        public CorreiosController(ICorreiosService correiosService)
        {
            _correiosService = correiosService;
        }

        [HttpGet("cep/{value}")]
        public async Task<IActionResult> ConsultaCep([FromRoute] string value)
        {
            return Ok(await _correiosService.ConsultaCep(value));
        }
    }
}
