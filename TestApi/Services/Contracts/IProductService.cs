using Generics.Models;

namespace TestApi.Services.Contracts
{
    public interface IProductService
    {


        ProductValuesModel GetTaxesByProduct(string name);

        List<ProductPreListModel> CalculateBasicSalesTax(List<ProductPreListModel> model);
        List<ProductPreListModel> CalculateImportedTax(List<ProductPreListModel> model);
        ProductPostListModel CalculateTaxes(List<ProductPreListModel> model);


    }
}
