using Microsoft.Data.SqlClient;
using Dapper;

namespace ProgramacaoWeb3.Repository
{
    public class ClientRepository
    {
        private readonly IConfiguration _configuration;

        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Client> GetCliente()
        {
            var query = "SELECT * FROM clientes";

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            
            using var conn = new SqlConnection(connectionString);

            return conn.Query<Client>(query).ToList();

        }

        public bool InsertClient(Client client)
        {
            var query = "INSERT INTO clientes VALUES (@cpf, @nome, @dataNascimento, @idade)";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Name);
            parameters.Add("dataNascimento", client.BirthDate);
            parameters.Add("idade", client.Age);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) > 0;
        }

        public bool UpdateClient(long id, Client client)
        {
            var query = "Update clientes SET cpf = @cpf, nome = @nome," +
                " dataNascimento = @dataNascimento, idade = @idade WHERE id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", client.Cpf);
            parameters.Add("nome", client.Name);
            parameters.Add("dataNascimento", client.BirthDate);
            parameters.Add("idade", client.Age);
            parameters.Add("id", client.Id);

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

        public List<Client> DescriptionClient(string cpf)
        {
            var query = "SELECT * FROM clientes WHERE cpf=@cpf";
            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Client>(query).ToList();
        }
    }
}
