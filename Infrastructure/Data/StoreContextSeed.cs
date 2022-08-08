using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext storeContext, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!storeContext.ProductBrands.Any())
            {
                await GenerateSeedData<ProductBrand>(
                    storeContext,
                    "../Infrastructure/Data/SeedData/brands.json",
                    storeContext.ProductBrands
                );
            }

            if (!storeContext.ProductType.Any())
            {
                await GenerateSeedData<ProductType>(
                    storeContext,
                    "../Infrastructure/Data/SeedData/types.json",
                    storeContext.ProductType
                );
            }
            
            if (!storeContext.Products.Any())
            {
                await GenerateSeedData<Product>(
                    storeContext,
                    "../Infrastructure/Data/SeedData/products.json",
                    storeContext.Products
                );
            }
        }
        catch (Exception e)
        {
            ILogger logger = loggerFactory.CreateLogger<StoreContextSeed>();
            
            logger.LogError(e.Message);
        }
    }

    public static async Task GenerateSeedData<T>(StoreContext storeContext, string path, DbSet<T> dbSet) where T : class
    {
        string seedData = File.ReadAllText(path);

        List<T> seedItems = JsonSerializer.Deserialize<List<T>>(seedData);

        foreach (T item in seedItems)
        {
            dbSet.Add(item);
        }

        await storeContext.SaveChangesAsync();
    }
}