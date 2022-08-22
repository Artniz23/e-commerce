using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductBrandController : BaseApiController
{
    private readonly IProductBrandRepository _productBrandRepository;

    public ProductBrandController(IProductBrandRepository productBrandRepository)
    {
        _productBrandRepository = productBrandRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        IReadOnlyList<ProductBrand> productBrands = await _productBrandRepository.GetProductBrandsAsync();

        return Ok(productBrands);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
    {
        ProductBrand brand = await _productBrandRepository.GetByIdAsync(id);

        return Ok(brand);
    }
}