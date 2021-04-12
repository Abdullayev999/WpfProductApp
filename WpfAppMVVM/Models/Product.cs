using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppMVVM.Models
{
    public class Product
    {
        public string Name { set; get; }
        public float Price { set; get; }
        public int Count { set; get; }
        public bool Favorite { set; get; }
        public DateTime Date { set; get; }
    }
}
