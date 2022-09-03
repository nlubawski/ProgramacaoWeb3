using Microsoft.Data.SqlClient;
using Dapper;
using ProgramacaoWeb3.Core.Interface;
using Microsoft.Extensions.Configuration;

namespace ProgramacaoWeb3.Infra.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Client> GetCliente()
        {
            var query = "SELECT * FROM clientes";
          
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Client>(query).ToList();

        }

        public bool InsertClient(Client client)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";

            var parameters = new DynamicParameters(client);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateClient(long id, Client client)
        {
            var query = "Update clientes SET cpf = @cpf, nome = @nome," +
                " dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";

            var parameters = new DynamicParameters(client);
            client.Id = id;

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteClient(long id)
        {
            var query = "DELETE FROM clientes WHERE id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", id);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public Client DescriptionClient(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf=@cpf";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.QueryFirstOrDefault<Client>(query, parameters);
        }
    }
}
