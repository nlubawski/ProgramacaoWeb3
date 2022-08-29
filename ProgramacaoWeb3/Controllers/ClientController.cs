using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoWeb3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private static List<Client> clientList = new List<Client>()
        { 
            new Client("teste1","99999999999", Convert.ToDateTime("2002/04/04")),
            new Client("teste2","88888888888", Convert.ToDateTime("1990/02/12")),
            new Client("teste3","77777777777", Convert.ToDateTime("2010/08/03")),
            new Client("teste4","66666666666", Convert.ToDateTime("2015/06/07")),
            new Client("teste5","55555555555", Convert.ToDateTime("1998/02/01")),
        };

        private readonly ILogger<ClientController> _logger; 
        private List<Client> clients { get; set; }

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
            clients = clientList.Select(client => new Client
            {
                BirthDate = client.BirthDate,
                Name = client.Name,
                Cpf = client.Cpf,
                Age = client.Age,
            }).ToList();
        }

        [HttpGet]
        public ActionResult<List<Client>> ReadClient()
        {
            return Ok(clients);
        }

        [HttpGet("{cpf}")]
        public ActionResult<Client> DetailsAirplaneId(string cpf)
        {
            var client = clientList.Find(client => client.Cpf == cpf);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<Client> InsertClient(Client client)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            clients.Add(client);
            return CreatedAtAction(nameof(UpdateClient), new { cpf = client.Cpf }, client);

        }

        [HttpPut("{cpf}")]
        public IActionResult UpdateClient(string cpf, Client clientUpdate)
        {
            var client = clientList.Find(client => client.Cpf == cpf);
            if (client == null)
            {
                return BadRequest("cpf não encontrado");
            }
            
            var index = clientList.IndexOf(client);
            clientList[index] = clientUpdate;
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteClient(string cpf)
        {
            var client = clientList.Find(client => client.Cpf == cpf);
            if(client != null)
            {
                clientList.Remove(client);
            }
            return NoContent();
        }
    }
}