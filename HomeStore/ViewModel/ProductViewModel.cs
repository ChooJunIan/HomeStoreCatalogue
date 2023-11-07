using HomeStore.Command;
using HomeStore.Model;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace HomeStore.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        private readonly Product _product;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string ID => _product.Id.ToString();

        public string Name => _product.Name;

        public string SalePrice => _product.SalePrice.ToString();

        public string ImageURL => _product.ImageURL;

        public ProductViewModel(Product product)
        {
            _product = product;
        }

        
    }
}
