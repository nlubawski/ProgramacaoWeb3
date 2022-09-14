using Microsoft.AspNetCore.Mvc;

namespace ProgramacaoWeb3.Core.Interface
{
    public interface IClientService
    {
        ActionResult<List<Client>> GetClients();

        bool InsertClient(Client client);

        bool UpdateClient(long id, Client client);

        bool DeleteClient(long id);

        Client? DescriptionClient(string cpf);
    }
}
