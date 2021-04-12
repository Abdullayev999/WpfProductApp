using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WpfAppMVVM.Models;

namespace WpfAppMVVM.Services
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Product GetProduct(string Name);
        ObservableCollection<Product> GetAllProducts();
    }
}
