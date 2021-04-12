using System;
using System.Collections.Generic;
using System.Text;

namespace WpfAppMVVM.Message
{
    public class NavigationMessage : IMessage
    {
        public Type ViewModelType { get; set; }
    }
}
