using Microsoft.AspNetCore.Mvc;
using PAW.API.Models;
using PAW.API.Repositories;

namespace PAW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _repository.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        var created = await _repository.CreateAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.ProductId) return BadRequest();

        var success = await _repository.UpdateAsync(product);
        if (!success) return NotFound();

        return NoContent();
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var success = await _repository.DeleteAsync(id);
        if (!success) return NotFound();

        return NoContent();
    }
}