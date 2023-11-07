using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeStore.Model
{
    public class ProductList
    {
        private readonly List<Product> _products;

        public ProductList()
        {
            _products = new List<Product>();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }
    }
}

    
