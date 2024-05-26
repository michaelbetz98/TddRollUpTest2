using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class ProductInputData
    {
        public string product {  get; set; }
        public string variant {  get; set; }
        public string gtin {  get; set; }
        public float? price {  get; set; }

        public ProductInputData(string gtin, string variant, string product, float? price) 
        {
            this.gtin = gtin;
            this.variant = variant;
            this.price = price;
            this.product = product;
        }
    }
}
