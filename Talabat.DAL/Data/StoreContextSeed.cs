using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data
{
    public class StoreContextSeed

    {

        public static async Task SeedAsync  (StoreContext storeContext ,ILoggerFactory loggerFactory)
        {
            try
            {

                if (!storeContext.brands.Any())
                {
                    var brandsdata = File.ReadAllText("../Talabat.DAL/Data/seeddata/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);

                    foreach (var brand in brands)
                        storeContext.Set<ProductBrand>().Add(brand);

                    await storeContext.SaveChangesAsync();
                }
                if (!storeContext.types.Any())
                {
                    var typesdata = File.ReadAllText("../Talabat.DAL/Data/seeddata/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesdata);

                    foreach (var type in types)
                        storeContext.Set<ProductType>().Add(type);

                    await storeContext.SaveChangesAsync();

                }


                if (!storeContext.products.Any())
                {
                    var  productdata = File.ReadAllText("../Talabat.DAL/Data/seeddata/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productdata);

                    foreach (var pro in products)
                        storeContext.Set<Product >().Add(pro);

                    await storeContext.SaveChangesAsync();

                }


            }
            catch (Exception ex)
            {

                var Logger = loggerFactory.CreateLogger<StoreContextSeed>();
                Logger.LogError(ex, ex.Message);
            }
         
        }
    }
}
