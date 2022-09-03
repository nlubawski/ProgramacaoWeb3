using Microsoft.AspNetCore.Mvc;
using ProgramacaoWeb3.Core.Interface;

namespace ProgramacaoWeb3.Core.Service
{
    public class ClientService : IClientService
    {
        readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool DeleteClient(long id)
        {
            return _clientRepository.DeleteClient(id);
        }

        public Client DescriptionClient(string cpf)
        {
            return _clientRepository.DescriptionClient(cpf);
        }

        public ActionResult<List<Client>> GetClients()
        {
            return _clientRepository.GetCliente();
        }

        public bool InsertClient(Client client)
        {
            return _clientRepository.InsertClient(client);
        }

        public bool UpdateClient(long id, Client client)
        {
            return _clientRepository.UpdateClient(id, client);
        }
    }
}
