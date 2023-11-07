using HomeStore.Model;
using HomeStore.ViewModel;
using System.Windows;

namespace HomeStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Store _homeStore;

        public App()
        {
            _homeStore = new Store("HomeStore");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_homeStore)
            };

            MainWindow.Show();
            
            base.OnStartup(e);
        }
    }
}
