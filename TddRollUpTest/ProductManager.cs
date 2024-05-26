using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class ProductManager
    {
        private static List<Product> products;

        public ProductManager()
        {
            products = new List<Product>();
        }
        public void ReadData(List<ProductInputData> data)
        {
            foreach (ProductInputData input in data)
            {
                TryAddProduct(input.product);
                GetProduct(input.product).TryAddVariant(input.variant);
                GetProduct(input.product).GetVariant(input.variant).TryAddGtint(input.gtin);
                GetProduct(input.product).GetVariant(input.variant).GetGtin(input.gtin).price = input.price;
            }

            products.ForEach(p =>
            {
                p.variants.ForEach(v => v.SetPrice());
                p.SetPrice();
            });

            //groupby test---------------------------
           
            //---------------------------------------


        }

        public NameValueOutput[] GetEOneForAll()
        {
            List<NameValueOutput> result = new List<NameValueOutput>();
            foreach(Product product in products)
            {
                result.Add(new NameValueOutput(product.name, product.price));
                foreach (Variant variant in product.variants)
                {
                    if(variant.price > product.price)
                    {
                        result.Add(new NameValueOutput(variant.name, variant.price));
                    }
                    foreach(Gtin gtin in variant.gtins)
                    {
                        if( gtin.price > variant.price)
                        {
                            result.Add(new NameValueOutput(gtin.name, gtin.price));
                        }
                    }
                }
            }
            return result.ToArray();
        }

        private void TryAddProduct(string name)
        {
            if (products == null || !products.Any(p => p.name == name))
            {
                Product temp = new Product(name);
                products.Add(temp);
            }
        }

        

        private Product GetProduct(string name)
        {
            return products.Where(p => p.name == name).Single();
        }
    }
}
