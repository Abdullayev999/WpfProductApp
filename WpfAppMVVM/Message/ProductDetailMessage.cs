using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppMVVM.Message
{
    class ProductDetailMessage : IMessage
    {
        public string NameProduct { get; set; }
    }
}
