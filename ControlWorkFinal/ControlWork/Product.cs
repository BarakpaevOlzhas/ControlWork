using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class Product
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Description { set; get; }

        public Product(string name, int price, string description)
        {
            Add(name, price, description);
        }

        public void Add(string name, int price,string description)
        {            
            Name = name;
            Price = price;
            Description = description;
        }

        public string BuyProduct(MainUser user)
        {
            return "";
        }
    }
}
