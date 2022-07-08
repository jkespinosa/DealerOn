using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Models
{
    public class ProductValuesModel
    {
        public int id { get; set; }
        public string? productName { get; set; }
        public decimal price { get; set; }
        public bool importedProduct { get; set; }
        public bool applyTaxes { get; set; }

        
    }

    public class ProductPreListModel
    {
        public decimal amount { get; set; }
        public decimal price { get; set; }
        public string? productName { get; set; }

    }

    public class ProductPostListModel
    {
        public IEnumerable<ProductPreListModel> productsList { get; set; }

        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }


    }


}
