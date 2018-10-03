using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class Category
    {
        public string Name { get; set; }

        public List<Product> Products = new List<Product>();
        
        public Category(string name)
        {
            Name = name;
        }
    }
}
