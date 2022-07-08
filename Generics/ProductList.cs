using Generics.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class ProductList
    {
        public static List<ProductValuesModel> productList()
        {
            //SIMULATING THE TABLE,

            //productName -> NAME OF THE PRODUCT
            //importedProduct -> WE DEFINE IF PRODUCT IS IMPORTED
            // applyTaxes -> WE DEFINE IF PRODUCT APPLY TAXES

            var ListOfProducts = new List<ProductValuesModel>();

            ListOfProducts.Add(new ProductValuesModel { productName = "Book",  importedProduct = false, applyTaxes =false});
            ListOfProducts.Add(new ProductValuesModel { productName = "Music CD", importedProduct= false, applyTaxes =true });
            ListOfProducts.Add(new ProductValuesModel { productName = "Chocolate bar", importedProduct= false, applyTaxes = false });
            ListOfProducts.Add(new ProductValuesModel { productName = "Imported box of chocolates", importedProduct=true , applyTaxes = false });
            ListOfProducts.Add(new ProductValuesModel { productName = "Imported bottle of perfume", importedProduct=true , applyTaxes =true });
            ListOfProducts.Add(new ProductValuesModel { productName = "Bottle of perfume", importedProduct= false, applyTaxes =true });
            ListOfProducts.Add(new ProductValuesModel { productName = "Packet of headache pills", importedProduct= false, applyTaxes = false });




            return ListOfProducts.ToList();

        }
    }
}
