using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class Product
    {
        public string name { get; set; }
        public float? price { get; set; }
        public List<Variant> variants { get; set; }

        public Product(string name)
        {
            variants = new List<Variant>();
            this.name = name;
        }

        public void TryAddVariant(string name)
        {
            if (variants == null || !variants.Any(v => v.name == name))
            {
                Variant temp = new Variant(name);
                variants.Add(temp);
            }
        }

        public Variant GetVariant(string name)
        {
            return variants.Where(v => v.name == name).Single();
        }

        public void SetPrice()
        {
            List<Variant> notNullsVariants = variants.Where(v => v.price > 0).ToList();
            price = notNullsVariants.Min(g => g.price);
        }
    }
}
