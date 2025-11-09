using Domain.Contracts;
using System.Text.Json;

namespace Presistance.Data;



public class DataSeed(ApplicatonDbcontext _dbcontext) : IDataSeed
{
    void IDataSeed.DataSeed()
    {
        try
        {


            if (_dbcontext.Database.GetPendingMigrations().Any())
            {

                _dbcontext.Database.Migrate();
            }


            if (!_dbcontext.ProductBrands.Any())
            {
                var ProductBrandData = File.ReadAllText("..\\Infrastructure\\Presistance\\DataJson\\brands.json");

                var ProductPrand = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);

                if (ProductPrand is not null && ProductPrand.Any())
                {

                    _dbcontext.ProductBrands.AddRange(ProductPrand);


                }
            }

            if (!_dbcontext.productTypes.Any())
            {
                var ProductTypeData = File.ReadAllText("..\\Infrastructure\\Presistance\\DataJson\\types.json");

                var ProductType = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);

                if (ProductType is not null && ProductType.Any())
                {

                    _dbcontext.productTypes.AddRange(ProductType);


                }
            }


            if (!_dbcontext.products.Any())
            {
                var ProductData = File.ReadAllText("..\\Infrastructure\\Presistance\\DataJson\\products.json");

                var Product = JsonSerializer.Deserialize<List<Product>>(ProductData);

                if (Product is not null && Product.Any())
                {

                    _dbcontext.products.AddRange(Product);


                }
                _dbcontext.SaveChanges();
            }
        }
        catch (Exception)
        {

            throw;
        }



    }
}
