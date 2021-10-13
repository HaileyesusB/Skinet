using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrand.Any()) {
                    var BrandsData = File.ReadAllText("../Infrastructure/SeedData/brands.json");
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                    foreach(var items in Brands)
                    {
                        context.ProductBrand.Add(items);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../Infrastructure/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Products>>(ProductsData);
                    foreach (var items in Products)
                    {
                        context.Products.Add(items);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductType.Any())
                {
                    var ProductTypeData = File.ReadAllText("./Infrastructure/SeedData/types.json");
                    var ProductType = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);
                    foreach (var items in ProductType)
                    {
                        context.ProductType.Add(items);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
