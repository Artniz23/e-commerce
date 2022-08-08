using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly StoreContext _context;

    public ProductTypeRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductType.ToListAsync();
    }
}