using System.Text.Json;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        await AddRangeAsync<ProductBrand>(context, "../Infrastructure/Data/SeedData/brands.json");
        await AddRangeAsync<ProductType>(context, "../Infrastructure/Data/SeedData/types.json");
        await AddRangeAsync<Product>(context, "../Infrastructure/Data/SeedData/products.json");
    }

    private static async Task AddRangeAsync<T>(StoreContext context, string path) where T : BaseEntity
    {
        if (!await context.Set<T>().AnyAsync())
        {
            var json = File.ReadAllText(path);
            var obj = JsonSerializer.Deserialize<List<T>>(json);
            if (obj == null) return;
            foreach (var item in obj)
            {
                context.Set<T>().Add(item);
            }
            await context.SaveChangesAsync();
        }
    }
}
