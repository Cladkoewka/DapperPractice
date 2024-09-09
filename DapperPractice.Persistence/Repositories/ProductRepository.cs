using System.Data;
using Dapper;
using Throw;
using DapperPractice.Domain.Models;

namespace DapperPractice.Persistence.Repositories;

public class ProductRepository(IDbConnectionFactory dbConnectionFactory)
{
    private readonly IDbConnectionFactory _dbConnectionFactory = dbConnectionFactory;
    public async Task CreateAsync(Product product)
    {
        // db connection
        using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync();
        //sql query
        string query = @"
            INSERT INTO products(id, name)
            VALUES (@Id, @Name)";
        // execute the query
        var result = await connection.ExecuteAsync(query, product);
        result.Throw().IfNegativeOrZero();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        // db connection
        using IDbConnection connection = await _dbConnectionFactory.CreateConnectionAsync();
        //sql query
        string query = @"
            SELECT id, name
            FROM products
            WHERE id = @Id";
        // execute the query
        return await connection.QueryFirstOrDefaultAsync<Product>(query, new {Id = id});

    }
}