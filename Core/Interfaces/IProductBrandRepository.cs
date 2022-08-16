using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IProductBrandRepository : IBaseRepository<ProductBrand>
{
    Task<ProductBrand> GetByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
}