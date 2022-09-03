using Microsoft.AspNetCore.Mvc;
using ProgramacaoWeb3.Core.Interface;

namespace ProgramacaoWeb3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
              
        readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Client>> GetClients()
        {
            return Ok(_clientService.GetClients());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Create(Client client)
        {
            if (!_clientService.InsertClient(client))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Create), client);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateClient(long id, Client client)
        {
        
            if (!_clientService.UpdateClient(id, client))
            {
                return NotFound();
            }                
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public IActionResult DeleteClient(long id)
        {
            if (!_clientService.DeleteClient(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("/cliente/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> DescriptionClient(string cpf)
        {
            return Ok(_clientService.DescriptionClient(cpf));
        }
    }
}