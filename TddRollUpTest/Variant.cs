using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class Variant
    {
        public string name { get; set; }
        public float? price { get; set; }

        public  List<Gtin> gtins { get; set; }

        public Variant(string name)
        {
            this.name = name;
            gtins = new List<Gtin>();
        }

        public void TryAddGtint(string name)
        {
            if (gtins == null || !gtins.Any(g => g.name == name))
            {
                Gtin temp = new Gtin(name);
                gtins.Add(temp);
            }
        }

        public Gtin GetGtin(string name)
        {
            return gtins.Where(g => g.name == name).Single();
        }

        public void SetPrice()
        {
            List<Gtin> notNullsGtins = gtins.Where(g => g.price>0).ToList();
            price = notNullsGtins.Min(g => g.price);
        }
    }
}
