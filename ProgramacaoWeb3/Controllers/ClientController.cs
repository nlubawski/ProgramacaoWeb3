using Microsoft.AspNetCore.Mvc;
using ProgramacaoWeb3.Repository;

namespace ProgramacaoWeb3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        public List<Client> ClientList { get; set; }
        private readonly IConfiguration _configuration;

        public ClientRepository _clientRepository;

        public ClientController(IConfiguration configuration)
        {
            ClientList = new List<Client>();
            _clientRepository = new ClientRepository(configuration);
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Client>> GetClients()
        {
            return Ok(_clientRepository.GetCliente());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Create(Client client)
        {
            if(!_clientRepository.InsertClient(client))
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
            var clients = ClientList;
            if (clients == null)
                return NotFound();

            _clientRepository.UpdateClient(id, client);
           return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public IActionResult DeleteClient(long id)
        {
            if(!_clientRepository.DeleteClient(id))
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
            return Ok(_clientRepository.DescriptionClient(cpf));
        }
    }
}