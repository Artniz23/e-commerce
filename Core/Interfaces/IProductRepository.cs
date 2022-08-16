using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product> GetProductByIdAsync(int id);

    Task<IReadOnlyList<Product>> GetProductAsync();
}