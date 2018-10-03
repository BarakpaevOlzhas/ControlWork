using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class Cart
    {
        public List<Product> Products = new List<Product>();
        
        public int FullPrice()
        {
            int price = 0;

            for (int i = 0; i < Products.Count; i++) 
            {
                price += Products[i].Price;
            }
            return price;
        }
    }
}
