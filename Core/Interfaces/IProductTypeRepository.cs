using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces;

public interface IProductTypeRepository : IBaseRepository<ProductType>
{
    Task<ProductType> GetByIdAsync(int id);
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}