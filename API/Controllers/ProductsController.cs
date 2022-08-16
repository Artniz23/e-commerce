using API.Dtos;
using AutoMapper;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;
    
    public ProductsController(
            IProductRepository productRepository,
            IMapper mapper
        )
    {
        this._productRepository = productRepository;
        this._mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetProducts()
    {
        ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification();

        IReadOnlyList<Product> products = await _productRepository.ListAsync(spec);

        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponseDto>>(products));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetProduct(int id)
    {
        ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification(id);

        Product product = await _productRepository.GetEntityWithSpec(spec);

        return _mapper.Map<Product, ProductResponseDto>(product);
    }
}