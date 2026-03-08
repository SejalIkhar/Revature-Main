using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // Temporary in-memory storage
    private static List<Product> products = new List<Product>();

    // GET: api/products
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public IActionResult Create(Product product)
    {
        products.Add(product);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product
        );
    }

    // PUT: api/products/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;

        return NoContent();
    }

    // DELETE: api/products/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        products.Remove(product);

        return NoContent();
    }
}