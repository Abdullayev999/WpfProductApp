using MVVMTools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppMVVM.Services;
using WpfAppMVVM.ViewModels;
using WpfAppMVVM.Views;

namespace WpfAppMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IProductRepository productRepository;
        public static IMessanger messanger;
        public static AddViewModel addViewModel;
        public static DetailViewModel detailViewModel;
        public static HomeViewModel homeViewModel;
        public static MainViewModel mainViewModel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            productRepository = new ProductRepository();
            messanger = new Messanger();
            addViewModel = new AddViewModel(messanger, productRepository);
            detailViewModel = new DetailViewModel(messanger, productRepository);
            homeViewModel = new HomeViewModel(messanger, productRepository);
            mainViewModel = new MainViewModel(messanger);
            mainViewModel.CurrentViewModel = homeViewModel;
            MainView mainView = new MainView();
            mainView.DataContext = mainViewModel;
            mainView.ShowDialog();
        }
    }
}
