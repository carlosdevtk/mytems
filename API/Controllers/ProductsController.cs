using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _repository;
    public ProductsController(IProductRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _repository.GetProductsAsync();

      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      return await _repository.GetProductByIdAsync(id);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsBrands()
    {
      return Ok(await _repository.GetProductsBrandsAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
    {
      return Ok(await _repository.GetProductsTypesAsync());
    }
  }
}