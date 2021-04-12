using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using WpfAppMVVM.Models;
using System.Text.Json;
using System.IO;

namespace WpfAppMVVM.Services
{
     class ProductRepository : IProductRepository
    {
        private ObservableCollection<Product> products;

        public ProductRepository()
        {
            Load();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Save();
        }

        public ObservableCollection<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProduct(string Name)
        {
            return products.First(i => i.Name.Equals(Name));
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
            Save();
        }

        private void Save()
        {
            string jsondata = JsonSerializer.Serialize(products);
            File.WriteAllText("save.sv", jsondata);
        }

        private void Load()
        {
            if (File.Exists("save.sv"))
            {
                string jsondata = File.ReadAllText("save.sv");
                products = JsonSerializer.Deserialize<ObservableCollection<Product>>(jsondata);
            }
            else
            {
                products = new ObservableCollection<Product>();
            }
        }
    }
}
