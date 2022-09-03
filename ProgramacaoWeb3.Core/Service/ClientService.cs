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

        public ActionResult<List<Client>> GetClients()
        {
            return _clientRepository.GetCliente();
        }
    }
}
