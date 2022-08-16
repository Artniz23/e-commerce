using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypeController(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        IReadOnlyList<ProductType> productTypes = await _productTypeRepository.GetProductTypesAsync();

        return Ok(productTypes);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductType>> GetProductType(int id)
    {
        ProductType type = await _productTypeRepository.GetByIdAsync(id);

        return Ok(type);
    }
}