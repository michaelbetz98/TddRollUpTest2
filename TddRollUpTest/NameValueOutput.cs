using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddRollUpTest
{
    public class NameValueOutput
    {
        public string name {  get; set; }
        public float? price { get; set; }

        public NameValueOutput(string name, float? price)
        {
            this.name = name;
            this.price = price;
        }
    }
}
