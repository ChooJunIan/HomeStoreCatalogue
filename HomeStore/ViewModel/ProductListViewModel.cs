using HomeStore.Command;
using HomeStore.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace HomeStore.ViewModel
{
    public class ProductListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ProductViewModel> _products;
        private readonly API _api;
        private int currentPage = 1;
        private bool loadingRequest = false;

        private int quantity;

        public ICommand IncreaseCommand { get; }

        public ICommand DecreaseCommand { get; }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChange(nameof(Quantity));
            }
        }
        
        public IEnumerable<ProductViewModel> Products => _products;

        public ProductListViewModel(API api)
        {
            _api = api;
            Quantity = 1;
            IncreaseCommand = new RelayCommand(IncreaseQuantity, CanIncreaseQuantity);
            DecreaseCommand = new RelayCommand(DecreaseQuantity, CanDecreaseQuantity);
            _products = new ObservableCollection<ProductViewModel>();

            LoadProductDataAsync();
        }

        private async void LoadProductDataAsync()
        {
            if (loadingRequest)
                return; 

            try
            {
                loadingRequest = true;

                string productData = await _api.GetProductDataAsync(currentPage);
                
                if (productData != null)
                { 
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    /* foreach (var product in products)
                    {
                        _products.Add(new ProductViewModel(product));
                    }
                    currentPage++; */
                }
                else
                {
                    Console.WriteLine("Error while fetching data.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error has ocurred.");
            }
            finally
            {
                loadingRequest = false;
            }
        }


        private bool CanIncreaseQuantity(object obj)
        {
            return true;
        }

        private void IncreaseQuantity(object obj)
        {
            Quantity++;
        }

        private bool CanDecreaseQuantity(object obj)
        {
            return Quantity > 0;
        }

        private void DecreaseQuantity(object obj)
        {
            Quantity--;
        }

    }
}
