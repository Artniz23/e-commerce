using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductBrandController : ControllerBase
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
}