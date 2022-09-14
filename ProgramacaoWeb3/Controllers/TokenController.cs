using Microsoft.AspNetCore.Mvc;
using ProgramacaoWeb3.Core.Interface;

namespace ProgramacaoWeb3.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ITokenService _tokenService;

        public TokenController(IClientService clientService, ITokenService tokenService)
        {
            _clientService = clientService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult CreateToken(string cpf)
        {
            var client = _clientService.DescriptionClient(cpf);
            if(client == null)
            {
                return BadRequest();
            }
            return Ok(_tokenService.GenerateTokenProdutos(client.Nome, client.Permissao));
        }
    }
}
