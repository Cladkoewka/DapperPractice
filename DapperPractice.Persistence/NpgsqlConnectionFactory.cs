using System.Data;
using Npgsql;

namespace DapperPractice.Persistence;

public class NpgsqlConnectionFactory(string connectionString) : IDbConnectionFactory
{
    private readonly string _connectionString = connectionString;
    public async Task<IDbConnection> CreateConnectionAsync()
    {
        NpgsqlConnection connection = new NpgsqlConnection(_connectionString);

        await connection.OpenAsync();

        return connection;
    }
}