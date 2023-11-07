using HomeStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeStore.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel(Store store)
        {
            API apiService = new API();
            CurrentViewModel = new ProductListViewModel(apiService);
        }
    }
}
