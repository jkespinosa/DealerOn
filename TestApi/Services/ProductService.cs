using Generics.Models;
using System.Configuration;
using TestApi.Services.Contracts;

namespace TestApi.Services
{
    public class ProductService : IProductService
    {
        //private readonly List<ProductModel> _peoductTaxesConfiguration;
        private readonly IConfiguration _configuration;
        private readonly decimal _BasicSalesTax;
        private readonly decimal _ImportedTax;
        private  decimal _sumTaxes;
        Generics.CalculateRoudTaxes CalculateRoudTaxes = new Generics.CalculateRoudTaxes();

        public ProductService(IConfiguration iConfig)
        {
            _configuration = iConfig;
            _BasicSalesTax = (_configuration.GetValue<decimal>("BasicSalesTax") / 100);
            _ImportedTax = (_configuration.GetValue<decimal>("ImportedTax") / 100);

        }
        public ProductPostListModel CalculateTaxes(List<ProductPreListModel> model)
        {
            var total = new ProductPostListModel();


            var calculateBasicSalesTax = CalculateBasicSalesTax(model).ToList();

            var calculateImportedTax = CalculateImportedTax(calculateBasicSalesTax).ToList();

           
            total.productsList = from line in calculateImportedTax
                              group line by line.productName into g
                       select new ProductPreListModel
                       {
                           productName = g.First().productName,
                           price = g.Sum(pc => pc.price),
                           amount = g.Count(),
                       };

            total.SalesTaxes = _sumTaxes;
            total.Total = ((decimal)calculateImportedTax.Sum(s => s.price));

            return total;
        }

        public List<ProductPreListModel> CalculateBasicSalesTax(List<ProductPreListModel> model)
        {
            var ListOfProductsWitheBasicSalesTax = new List<ProductPreListModel>();

            foreach (var item in model)
            {
                var TaxesByProduct = GetTaxesByProduct(item.productName);

                if (TaxesByProduct.applyTaxes == true)
                {

                    var CalcBasicSalesTax = (item.price * _BasicSalesTax);
                    //var RoundBasicSalesTax = Math.Ceiling(CalcBasicSalesTax);


                    // decimal asdasd = Convert.ToDecimal(formatString);

                    var newTaxedRoudValue = CalculateRoudTaxes.NewTaxedRoudValue(CalcBasicSalesTax);

                    _sumTaxes += newTaxedRoudValue;
                    var SumTaxItemPrice =  item.price + newTaxedRoudValue;

                    ListOfProductsWitheBasicSalesTax.Add(new ProductPreListModel { productName = item.productName, amount = item.amount, price = SumTaxItemPrice });
                }
                else
                {
                    ListOfProductsWitheBasicSalesTax.Add(new ProductPreListModel { productName = item.productName, amount = item.amount, price = item.price });
                }
            }

            return ListOfProductsWitheBasicSalesTax;
        }

        public List<ProductPreListModel> CalculateImportedTax(List<ProductPreListModel> model)
        {
            var ListOfProductsWithImportedTax = new List<ProductPreListModel>();

            foreach (var item in model)
            {
                var TaxesByProduct = GetTaxesByProduct(item.productName);

                if (TaxesByProduct.importedProduct == true)
                {
                    var CalcImportedTax = item.price * _ImportedTax;

                    var newTaxedRoudValue = CalculateRoudTaxes.NewTaxedRoudValue(CalcImportedTax);


                   // var RoundCalcImportedTax = Math.Ceiling(CalcImportedTax);
                    _sumTaxes += newTaxedRoudValue;

                    var SumTaxItemPrice = item.price + newTaxedRoudValue;

                    ListOfProductsWithImportedTax.Add(new ProductPreListModel { productName = item.productName, amount = item.amount, price = SumTaxItemPrice });
                }
                else
                {
                    ListOfProductsWithImportedTax.Add(new ProductPreListModel { productName = item.productName, amount = item.amount, price = item.price });
                }

            }

            return ListOfProductsWithImportedTax;
        }

        public ProductValuesModel GetTaxesByProduct(string name)
        {
            var product = Generics.ProductList.productList().Where(s => s.productName == name).FirstOrDefault();

            return product;

        }

    }
}
