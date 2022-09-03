namespace ProgramacaoWeb3.Core.Interface
{
    public interface IClientRepository
    {
        List<Client> GetCliente();

        bool InsertClient(Client client);

        bool UpdateClient(long id, Client client);

        bool DeleteClient(long id);

        Client DescriptionClient(string cpf);

    }
}
