using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeStore.Model
{
    public class Store
    {
        private readonly ProductList _productList;

        public string Name { get; }

        public Store(string name)
        {
            Name = name;
            _productList = new ProductList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList.GetAllProducts();
        }
    }
}
