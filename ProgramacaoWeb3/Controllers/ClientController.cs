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

        //https://localhost:7185/Client
        [HttpGet]
        public List<Client> Get(int index)
        {
            return clients;
        }

        [HttpPost]
        public Client Insert(Client client)
        {
            clients.Add(client);
            return client;

        }

        [HttpPut]
        public Client Update(int index, Client tempo)
        {
            clients[index] = tempo;
            return clients[index];
        }

        [HttpDelete]
        public List<Client> Deletar(int index) //o certo é nao retornar nada
        {
            clients.RemoveAt(index);
            return clients; 

        }

    }
}