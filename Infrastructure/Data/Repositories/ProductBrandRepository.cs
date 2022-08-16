using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ProductBrandRepository : BaseRepository<ProductBrand>, IProductBrandRepository
{
    private readonly StoreContext _context;

    public ProductBrandRepository(StoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ProductBrand> GetByIdAsync(int id)
    {
        return await _context.ProductBrands.FindAsync(id);
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
        return await _context.ProductBrands.ToListAsync();
    }
}