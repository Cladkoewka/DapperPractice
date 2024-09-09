using DapperPractice.Domain.Models;
using DapperPractice.Persistence.Repositories;

namespace DapperPractice.Logic.Services;

public class ProductsService(ProductRepository repository)
{
    private readonly ProductRepository _repository = repository;

    public async Task CreateAsync(Product product)
    {
        await _repository.CreateAsync(product);
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}