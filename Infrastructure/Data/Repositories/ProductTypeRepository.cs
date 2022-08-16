using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
{
    private readonly StoreContext _context;

    public ProductTypeRepository(StoreContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ProductType> GetByIdAsync(int id)
    {
        return await _context.ProductType.FindAsync(id);
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await _context.ProductType.ToListAsync();
    }
}