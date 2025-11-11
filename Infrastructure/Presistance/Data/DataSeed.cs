using Domain.Contracts;
using System.Text.Json;

namespace Presistance.Data;



public class DataSeed(ApplicatonDbcontext _dbcontext) : IDataSeed
{
   public  async Task DataSeedAsync()
    {
        try
        {


            if ((await _dbcontext.Database.GetPendingMigrationsAsync()).Any())
            {

               await  _dbcontext.Database.MigrateAsync();
            }


            if (!_dbcontext.ProductBrands.Any())
            {
                var ProductBrandData = File.OpenRead("..\\Infrastructure\\Presistance\\DataJson\\brands.json");

                var ProductPrand = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);

                if (ProductPrand is not null && ProductPrand.Any())
                {

                    await _dbcontext.ProductBrands.AddRangeAsync(ProductPrand);


                }
            }

            if (!_dbcontext.productTypes.Any())
            {
                var ProductTypeData = File.OpenRead("..\\Infrastructure\\Presistance\\DataJson\\types.json");

                var ProductType =  await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);

                if (ProductType is not null && ProductType.Any())
                {

                   await _dbcontext.productTypes.AddRangeAsync(ProductType);


                }
            }


            if (!_dbcontext.products.Any())
            {
                var ProductData = File.OpenRead("..\\Infrastructure\\Presistance\\DataJson\\products.json");

                var Product = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);

                if (Product is not null && Product.Any())
                {

                    await _dbcontext.products.AddRangeAsync(Product);


                }
               await  _dbcontext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {

            throw;
        }



    }
}
