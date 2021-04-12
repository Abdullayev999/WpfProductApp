using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using WpfAppMVVM.Message;
using WpfAppMVVM.Models;
using WpfAppMVVM.Services;

namespace WpfAppMVVM.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public IMessanger messanger { get; set; }
        public IProductRepository ProductRepository { get; set; }

        public ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get => products;
            set => ChangeProp(out products, value);
        }
        private Command<Product> removeProduct;
        public Command<Product> RemoveProduct => removeProduct ??= new Command<Product>(Remove);
        private Command navAdd;
        public Command NavAdd => navAdd ??= new Command(()=> { messanger.Send<NavigationMessage>(new NavigationMessage { ViewModelType = typeof(AddViewModel) }); });

        private Command<string> navDetail;
        public Command<string> NavDetail => navDetail ??= new Command<string>(name => 
        {
            messanger.Send<ProductDetailMessage>(new ProductDetailMessage { NameProduct = name });
            messanger.Send<NavigationMessage>(new NavigationMessage { ViewModelType = typeof(DetailViewModel) }); 
        });

        public void Remove(Product param)
        {
            if (param != null)
                ProductRepository.RemoveProduct(param);
        }
        public HomeViewModel(IMessanger messanger, IProductRepository productRepository)
        {
            this.messanger = messanger;
            this.ProductRepository = productRepository;
            this.Products = this.ProductRepository.GetAllProducts();
        }
    }
}
