using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeStore.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public string ImageURL { get; set; }

        public Product(int id, string name, double salePrice, string imageURL)
        {
            Id = id;
            Name = name;
            SalePrice = salePrice;
            ImageURL = imageURL;
        }
    }
}
