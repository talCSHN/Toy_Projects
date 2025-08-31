using SmartFactory.ViewModels;
using SmartFactory.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SmartFactory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var viewModel = new MainViewModel();
            var view = new MainView
            {
                DataContext = viewModel,
            };
            view.Show();
        }
    }

}
