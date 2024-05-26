using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class Gtin
    {
        public string name {  get; set; }
        public float? price { get; set; }

        public Gtin(string name)
        {  
            this.name = name;
        }
    }
}
