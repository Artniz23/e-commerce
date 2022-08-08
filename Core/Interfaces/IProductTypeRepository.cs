using Core.Entities;

namespace Core.Interfaces;

public interface IProductTypeRepository
{
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}