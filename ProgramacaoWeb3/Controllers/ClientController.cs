using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoWeb3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        string[] names = new[] { "teste1", "teste2", "teste3", "teste4", "teste5" };

        private readonly ILogger<ClientController> _logger; 
        private List<Client> clients { get; set; }

        public ClientController(ILogger<ClientController> logger)
        {
            clients = Enumerable.Range(1, 5).Select(index => new Client
            {
                Cpf = String.Concat(Enumerable.Repeat(index + 1, 9)),
                Name = names[index - 1],
                BirthDate = DateTime.Now.AddYears(-(index * 10))
            }).ToList();
        }

        [HttpGet("/clientes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Client>> ReadClient([FromQuery] int index, int index2)
        {
            return Ok(clients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/cliente/{cpf}/detalhes")] 
        public ActionResult<Client> DetailsClientId(string cpf)
        {
            var client = clients.Find(client => client.Cpf == cpf);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }


        //[HttpPost("/cliente/cadastrar ")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult<Client> InsertClient(Client client)
        //{
        //    if (client == null)
        //    {
        //        return BadRequest("cliente não cadastrado");
        //    }
        //    clients.Add(client);
        //    return CreatedAtAction(nameof(DetailsClientId), client);
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Client> Create(Client client)
        {
            clients.Add(client);
            return CreatedAtAction(nameof(Create), client);
        }

        [HttpPut("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateClient(string cpf, Client clientUpdate)
        {
            var client = clients.Find(client => client.Cpf == cpf);
            if (client == null)
            {
                return BadRequest("cpf não encontrado");
            }
            
            var index = clients.IndexOf(client);
            clients[index] = clientUpdate;
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]
        public IActionResult DeleteClient(string cpf)
        {
            var client = clients.Find(client => client.Cpf == cpf);
            if(client != null)
            {
                clients.Remove(client);
            }
            return NoContent();
        }
    }
}