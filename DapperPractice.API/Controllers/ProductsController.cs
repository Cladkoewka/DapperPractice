using DapperPractice.Domain.Models;
using DapperPractice.Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperPractice.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductsService _productsService;

    public ProductsController(ProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest("Product cannot be null.");
        }

        await _productsService.CreateAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productsService.GetAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}