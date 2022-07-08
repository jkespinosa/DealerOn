using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class CalculateRoudTaxes
    {
        public  decimal NewTaxedRoudValue(decimal CalcBasicSalesTax)
        {

            //var RoundBasicSalesTax = Math.Ceiling(CalcBasicSalesTax);

            //convert to string to split decimals
            string RoundBasicSalesTaxasd = CalcBasicSalesTax.ToString();

            //we validade the second position of decimal
            float numDecimal = float.Parse("0," + RoundBasicSalesTaxasd.Split('.')[1][1]);

            //condition to validate if is upper 5, 

            //decimal d = numDecimal >= 5 ? Convert.ToDecimal(float.Parse("0," + RoundBasicSalesTaxasd.Split('.')[1][0])) + 1 : CalcBasicSalesTax;

            decimal newTaxedRoudValue;
            if (numDecimal >= 5)
            {
               var  d=  Convert.ToDecimal(float.Parse("0," + RoundBasicSalesTaxasd.Split('.')[1][0])) + 1;

                // delete the decimals
                var x = CalcBasicSalesTax - (CalcBasicSalesTax - Math.Truncate(CalcBasicSalesTax));

                //add new decimal value 
                string formatString = "0." + d;

                //we convert to decimal the new value of tax
                 newTaxedRoudValue = x + Convert.ToDecimal(formatString);
            }
            else {
                newTaxedRoudValue = CalcBasicSalesTax;
            }
                      

            // decimal asdasd = Convert.ToDecimal(formatString);

            return newTaxedRoudValue;
        }
    }
}
